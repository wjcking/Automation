using Sinowyde.DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DOP.DataModel;
using NHibernate.Criterion;
using Sinowyde.DataModel;
using Sinowyde.RTModel;
using NHibernate;

namespace Sinowyde.DOP.DataLogic
{
    public class DOPDataLogic : DataLogicBase
    {
        public DOPDataLogic()
            : base(new DOPSessionManager())
        {
        }

        /// <summary>
        /// 单例数据库访问对象
        /// </summary>
        private static DOPDataLogic instance = null;

        private static object _lock = new object();

        public static DOPDataLogic Instance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new DOPDataLogic();
                }
            }


            return instance;
        }

        public IList<Variable> GetVarList(VarDirectionType dir = VarDirectionType.Read, VariableType dt = VariableType.AM, string keyword = "")
        {
            var criterions = new List<AbstractCriterion>();
            if (dir != null)
                criterions.Add(Restrictions.Eq("DirectionType", dir));
            if (dt != null)
                criterions.Add(Restrictions.Eq("DataType", dt));

            if (keyword != "")
            {
                criterions.Add(
                    Restrictions.Or(
                    Restrictions.Like("Name", keyword, MatchMode.Anywhere),
                Restrictions.Like("ShowName", keyword, MatchMode.Anywhere)));
            }
            var pointList = Instance().Query<Variable>(criterions, null, 0, 1);


            return pointList;
        }

        /// <summary>
        /// 获取服务地址
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetServiceAddress(string name, ServiceCfgType serviceType)
        {
            var criterions = new List<AbstractCriterion>();
            criterions.Add(Restrictions.Eq("Name", name));
            criterions.Add(Restrictions.Eq("ServiceType", serviceType));
            IList<ServiceCfg> cfgs = this.Query<ServiceCfg>(criterions, null, 0, 0);
            if (cfgs == null || cfgs.Count == 0)
                return string.Empty;
            return cfgs[0].Address;
        }
        /// <summary>
        /// 获取所有broker配置
        /// </summary>
        /// <returns></returns>
        public IList<ServiceCfg> GetBrokerAddress()
        {
            var criterions = new List<AbstractCriterion>();
            criterions.Add(Restrictions.Or(Restrictions.Eq("ServiceType", ServiceCfgType.BrokerPub),
                Restrictions.Eq("ServiceType", ServiceCfgType.BrokerSub)));
            IList<ServiceCfg> cfgs = this.Query<ServiceCfg>(criterions, null, 0, 0);
            return cfgs;
        }


        #region  DataModel.Control

        public List<T> GetAllBy<T>() where T : Entity, new()
        {
            List<T> list = Instance().Query(typeof(T), null, null, 0, 0).Cast<T>().ToList<T>();
            return list;
        }

        public List<Variable> GetByIOUnitID(long id)
        {
            var criterionsVariable = new List<AbstractCriterion> { Restrictions.Eq("IOUnit.ID", id) };

            return Query<Variable>(criterionsVariable, null, 0, 0).ToList();
        }

        public List<Variable> GetByIOChannelID(long id)
        {
            List<IOUnit> iounits = GetIOUnitByChannelID(id);
            var ids = (from c
            in iounits
                       select c.ID).ToArray<long>();
            var criterionsVariable = new List<AbstractCriterion> { Restrictions.In("IOUnit.ID", ids) };

            return Query<Variable>(criterionsVariable, null, 0, 0).ToList();
        }

        public List<IOChannel> GetIOChannelByServerID(long id)
        {
            var criterionsVariable = new List<AbstractCriterion> { Restrictions.Eq("IOServer.ID", id) };

            return Query<IOChannel>(criterionsVariable, null, 0, 0).ToList();
        }

        public List<IOUnit> GetIOUnitByChannelID(long id)
        {
            var criterionsVariable = new List<AbstractCriterion> { Restrictions.Eq("Channel.ID", id) };

            return Query<IOUnit>(criterionsVariable, null, 0, 0).ToList();
        }

        public List<Variable> GetVariable(string variableName, string variableNumber, bool? isTransfer, bool? isCompressed,
            long deviceId, VariableType dataType, VarDirectionType varDirectionType, long unitId)
        {
            var criterions = new List<AbstractCriterion>();
            #region 逻辑判断条件
            if (unitId > 0)
            {
                criterions.Add(Restrictions.Eq("IOUnit.ID", unitId));
            }
            if (!string.IsNullOrEmpty(variableName))
            {
                criterions.Add(Restrictions.Like("Name", variableName, MatchMode.Anywhere));
            }
            if (!string.IsNullOrEmpty(variableNumber))
            {
                criterions.Add(Restrictions.Like("Number", variableNumber, MatchMode.Anywhere));
            }
            if (isTransfer != null)
            {
                criterions.Add(Restrictions.Eq("IsTransfer", (bool)isTransfer));
            }
            if (isCompressed != null)
            {
                criterions.Add(Restrictions.Eq("IsCompressed", (bool)isCompressed));
            }
            if (deviceId > 0)
            {
                criterions.Add(Restrictions.Eq("Device.ID", deviceId));
            }
            if (dataType != null)
            {
                criterions.Add(Restrictions.Eq("DataType", dataType));
            }

            if (varDirectionType != null)
            {
                criterions.Add(Restrictions.Eq("DirectionType", varDirectionType));
            }
            #endregion
            List<Variable> pointList = Instance().Query<Variable>(criterions, null, 0, 1).ToList();

            return pointList;
        }

        public List<AlarmRule> GetAlarmRuleByVariable(long variableId)
        {
            var criterionsVariable = new List<AbstractCriterion> { Restrictions.Eq("Variable.ID", variableId) };

            return Query<AlarmRule>(criterionsVariable, null, 0, 0).ToList();
        }

        /// <summary>
        /// 判断实体中某一字段 是否存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsExist<T>(object value, string name = "Name") where T : Entity
        {
            if (value != null)
            {
                var criterionsVariable = new List<AbstractCriterion> { Restrictions.Eq(name, value) };
                T model = Query(typeof(T), criterionsVariable, null, 0, 0).Cast<T>().FirstOrDefault();
                return model != null && model.ID > 0;
            }
            return false;
        }

        public bool IsExistVariable(long deviceId, int variableAddress)
        {
            var criterions = new List<AbstractCriterion>
                {
                    Restrictions.And(Restrictions.Where<Variable>(o => o.Device.ID == deviceId),
                                     Restrictions.Where<Variable>(o => o.Address == variableAddress))
                };

            Variable model = Query<Variable>(criterions, null, 0, 0).FirstOrDefault();
            return model != null && model.ID > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName">中文名称</param>
        /// <param name="variableNumber">点名</param>
        /// <param name="isTransfer">是否上传</param>
        /// <param name="deviceId">设备ID</param>
        /// <param name="variableType">变量类型</param>
        /// <param name="dataType">数据类型</param>
        /// <param name="varDirectionType">采集类型</param>
        /// <param name="unitId">所在单元ID</param>
        /// <returns></returns>
        public List<Variable> GetVariable(string variableName, string variableNumber, bool? isTransfer,
            long deviceId, VariableType? variableType, DataType? dataType, VarDirectionType? varDirectionType, long unitId)
        {
            var criterions = new List<AbstractCriterion>();
            #region 逻辑判断条件
            if (unitId > 0)
            {
                criterions.Add(Restrictions.Eq("IOUnit.ID", unitId));
            }
            if (!string.IsNullOrEmpty(variableName))
            {
                criterions.Add(Restrictions.Like("Name", variableName, MatchMode.Anywhere));
            }
            if (!string.IsNullOrEmpty(variableNumber))
            {
                criterions.Add(Restrictions.Like("Number", variableNumber, MatchMode.Anywhere));
            }
            if (isTransfer != null)
            {
                criterions.Add(Restrictions.Eq("IsTransfer", (bool)isTransfer));
            }
            if (dataType.HasValue)
            {
                criterions.Add(Restrictions.Eq("DataType", dataType));
            }
            if (deviceId > 0)
            {
                criterions.Add(Restrictions.Eq("Device.ID", deviceId));
            }
            if (variableType.HasValue)
            {
                criterions.Add(Restrictions.Eq("VariableType", variableType));
            }

            if (varDirectionType.HasValue)
            {
                criterions.Add(Restrictions.Eq("DirectionType", varDirectionType));
            }
            #endregion
            List<Variable> pointList = Instance().Query<Variable>(criterions, null, 0, 0).ToList();

            return pointList;
        }

        public List<Variable> GetReadWriteVaribale(VarDirectionType? type = null)
        {
            var criterions = new List<AbstractCriterion>();
            if (type == null)
            {
                criterions.Add(Restrictions.Or(Restrictions.Eq("DirectionType", VarDirectionType.Read), Restrictions.Eq("DirectionType", VarDirectionType.Write)));
            }
            else
            {
                criterions.Add(Restrictions.Eq("DirectionType", type));
            }

            List<Variable> pointList = Instance().Query<Variable>(criterions, null, 0, 0).ToList();
            return pointList;
        }

        /// <summary>
        /// 获取 单元下的 VarDirectionType = null  或 VarDirectionType.Read 或 VarDirectionType.Write
        /// </summary>
        /// <param name="IOUnitID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Variable> GetReadWriteVaribale(long IOUnitID, VarDirectionType? type = null)
        {
            var criterions = new List<AbstractCriterion>();
            criterions.Add(Restrictions.Eq("IOUnit.ID", IOUnitID));
            if (type == null)
            {
                criterions.Add(Restrictions.Or(Restrictions.Eq("DirectionType", VarDirectionType.Read), Restrictions.Eq("DirectionType", VarDirectionType.Write)));
            }
            else
            {
                criterions.Add(Restrictions.Eq("DirectionType", type));
            }

            List<Variable> pointList = Instance().Query<Variable>(criterions, null, 0, 0).ToList();
            return pointList;
        }

        /// <summary>
        /// 获取计算变量
        /// </summary>
        /// <returns></returns>
        public List<Variable> GetCalcVariabel()
        {
            var criterions = new List<AbstractCriterion>();

            criterions.Add(Restrictions.Eq("DirectionType", VarDirectionType.Calc));

            List<Variable> pointList = Instance().Query<Variable>(criterions, null, 0, 0).ToList();
            return pointList;
        }

        /// <summary>
        /// 获取中间变量
        /// </summary>
        /// <returns></returns>
        public List<Variable> GetTempVariabel()
        {
            var criterions = new List<AbstractCriterion>();

            criterions.Add(Restrictions.Eq("DirectionType", VarDirectionType.Temp));

            List<Variable> pointList = Instance().Query<Variable>(criterions, null, 0, 0).ToList();
            return pointList;
        }

        public List<Variable> GetVaribaleBy(string variableName,
            long deviceId, VariableType? variableType, bool? isCalcVaribale)
        {
            var criterions = new List<AbstractCriterion>();
            #region 逻辑判断条件

            if (!string.IsNullOrEmpty(variableName))
            {
                criterions.Add(Restrictions.Like("Name", variableName, MatchMode.Anywhere));
            }

            if (deviceId > 0)
            {
                criterions.Add(Restrictions.Eq("Device.ID", deviceId));
            }
            if (variableType.HasValue)
            {
                criterions.Add(Restrictions.Eq("VariableType", variableType));
            }

            if (isCalcVaribale.HasValue && !isCalcVaribale.Value)
            {
                criterions.Add(Restrictions.Not(Restrictions.Eq("DirectionType", VarDirectionType.Calc)));
            }

            #endregion
            List<Variable> pointList = Instance().Query<Variable>(criterions, null, 0, 0).ToList();

            return pointList;
        }
        #endregion

        #region Alarm.Control
        /// <summary>
        /// 根据条件查询RTAlarm
        /// </summary>
        /// <param name="varNumber">点号</param>
        /// <param name="level">报警等级</param>
        /// <param name="type">报警类型</param>
        /// <param name="timestampBegin">报警开始时间</param>
        /// <param name="timestampEnd">报警结束时间</param>
        /// <param name="confirmTimeBegin">确认报警开始时间</param>
        /// <param name="confirmTimeEnd">确认报警结束时间</param>
        /// <param name="isConfirm">是否确认</param>
        /// <param name="person">确认人</param>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public IList<RTAlarm> GetRTAlarmBy(string varNumber,
            Sinowyde.DOP.DataModel.AlarmLevel? level,
            Sinowyde.DOP.DataModel.AlarmType? type,
            DateTime timestampBegin,
            DateTime timestampEnd,
            DateTime confirmTimeBegin,
            DateTime confirmTimeEnd,
            bool? isConfirm,
            string person = "",
            int pageIndex = 0,
            int pageSize = 0)
        {
            var criterions = new List<AbstractCriterion>();
            if (!string.IsNullOrEmpty(varNumber))
            {
                criterions.Add(Restrictions.Like("VarNumber", varNumber, MatchMode.Anywhere));
            }
            if (level.HasValue)
            {
                criterions.Add(Restrictions.Eq("Level", level));
            }
            if (type.HasValue)
            {
                criterions.Add(Restrictions.Eq("Type", type));
            }
            if (timestampEnd.Equals(DateTime.MinValue)) { timestampEnd = DateTime.MaxValue; }
            criterions.Add(Restrictions.Between("Timestamp", timestampBegin, timestampEnd));
            if (!confirmTimeBegin.Equals(DateTime.MinValue) && !confirmTimeEnd.Equals(DateTime.MinValue))
            {
                criterions.Add(Restrictions.Between("ConfirmTime", confirmTimeBegin, confirmTimeEnd));
            }

            if (isConfirm.HasValue && (bool)isConfirm)
            {
                criterions.Add(Restrictions.IsNotNull("Operator"));
            }
            if (!string.IsNullOrEmpty(person))
            {
                criterions.Add(Restrictions.Like("Operator", person));
            }
            IList<Order> orders = new List<Order>();
            orders.Add(Order.Desc("Timestamp"));
            orders.Add(Order.Desc("ConfirmTime"));
            orders.Add(Order.Desc("Operator"));
            return this.Query<RTAlarm>(criterions, orders, pageIndex, pageSize);

        }

        public IList<Sinowyde.DOP.DataModel.RTEvent> GetRtEventBy(string varNumber,
            Sinowyde.DOP.DataModel.AlarmLevel? level,
            Sinowyde.DOP.DataModel.AlarmType? type,
            DateTime timestampBegin,
            DateTime timestampEnd,
            string EventType,
            int pageIndex = 0,
            int pageSize = 0)
        {
            var criterions = new List<AbstractCriterion>();
            if (!string.IsNullOrEmpty(varNumber))
            {
                criterions.Add(Restrictions.Like("VarNumber", varNumber, MatchMode.Anywhere));
            }
            if (level.HasValue)
            {
                criterions.Add(Restrictions.Eq("Level", level));
            }
            if (type.HasValue)
            {
                criterions.Add(Restrictions.Eq("Type", type));
            }
            if (!string.IsNullOrEmpty(EventType))
            {
                criterions.Add(Restrictions.Like("EventType", EventType, MatchMode.Anywhere));
            }

            if (timestampEnd.Equals(DateTime.MinValue)) { timestampEnd = DateTime.MaxValue; }
            criterions.Add(Restrictions.Between("Timestamp", timestampBegin, timestampEnd));

            IList<Order> orders = new List<Order>();
            orders.Add(Order.Desc("Timestamp"));

            return this.Query<Sinowyde.DOP.DataModel.RTEvent>(criterions, orders, pageIndex, pageSize);

        }

        /// <summary>
        /// 实时刷新（RTAlarm 和 RTEvent）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="topCount"></param>
        /// <returns></returns>
        public IList<T> GetTopItems<T>(int topCount)
        {
            IList<Order> orders = new List<Order>();
            orders.Add(Order.Desc("Timestamp"));
            return this.Query(typeof(T), null, orders, 0, topCount).Cast<T>().ToList();
        }
        #endregion

        #region RTData.Control

        /// <summary>
        /// 根据Number name DirectionType DeviceID 查询变量
        /// </summary>
        /// <param name="Keyword"></param>
        /// <param name="VarDirectionType"></param>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public IList<Variable> GetVariableWithRTData(string Keyword, VarDirectionType? VarDirectionType, long? DeviceID)
        {
            var criterions = new List<AbstractCriterion>();
            if (!string.IsNullOrEmpty(Keyword))
            {
                criterions.Add(Restrictions.Like("Number", Keyword, MatchMode.Anywhere));
                criterions.Add(Restrictions.Like("Name", Keyword, MatchMode.Anywhere));
            }
            if (VarDirectionType.HasValue)
            {
                criterions.Add(Restrictions.Eq("DirectionType", VarDirectionType));
            }

            if (DeviceID.HasValue && DeviceID > 0)
            {
                criterions.Add(Restrictions.Eq("Device.ID", DeviceID));
            }

            IList<Order> orders = new List<Order>();

            return this.Query<Variable>(criterions, orders, 0, 0);
        }
        #endregion

        #region DataReport.Control

        public List<RTValue> GetRTValueBy(string[] numbers, DateTime beginDate, DateTime endDate)
        {
            if (numbers.Length <= 0)
                return null;
            var criterions = new List<AbstractCriterion>();
            criterions.Add(Restrictions.In("VarNumber", numbers));
            criterions.Add(Restrictions.Ge("Timestamp", beginDate));
            criterions.Add(Restrictions.Le("Timestamp", endDate));
            IList<Order> orders = new List<Order>();
            orders.Add(Order.Desc("Timestamp"));

            return Instance().Query<RTValue>(criterions, orders, 0, 0).ToList();
        }

        #endregion

        /// <summary>
        /// 获得指定Number下的变量对象
        /// </summary>
        /// <param name="variableNumber"></param>
        /// <returns></returns>
        public Variable GetVariable(string variableNumber)
        {
            var criterions = new List<AbstractCriterion>();
            if (!string.IsNullOrEmpty(variableNumber))
            {
                criterions.Add(Restrictions.Eq("Number", variableNumber));
            }
            List<Variable> pointList = Instance().Query<Variable>(criterions, null, 0, 0).ToList();

            return pointList[0];
        }

        /// <summary>
        /// 构造通道查询条件
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="condValue"></param>
        private void GetChannelByIOSeverQuery(ICriteria criteria, object condValue)
        {
            criteria.CreateCriteria("IOServer").Add(Restrictions.Eq("Name", condValue.ToString()));
        }
        /// <summary>
        /// 根据名称获取通道信息
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public IList<IOChannel> GetChannelByIOSever(string Name)
        {
            return this.Query<IOChannel>(GetChannelByIOSeverQuery, Name, 0, 0);
        }

        /// <summary>
        /// 构造通道查询条件
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="condValue"></param>
        private void GetVariableByIChannelQuery(ICriteria criteria, object condValue)
        {
            criteria.CreateCriteria("IOUnit").CreateCriteria("IOChannel").
                Add(Restrictions.Eq("ID", condValue));
        }
        /// <summary>
        /// 根据名称获取通道信息
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public IList<Variable> GetVariableByChannel(long channelID)
        {
            return this.Query<Variable>(GetVariableByIChannelQuery, channelID, 0, 0);
        }

        public IList<Variable> GetVariableList(long deviceID = 0, DataType dt = DataType.data_short, string variableName = "")
        {
            var criterions = new List<AbstractCriterion>();
            if (deviceID > 0)
                criterions.Add(Restrictions.Eq("Device.ID", deviceID));
            if (dt != 0)
                criterions.Add(Restrictions.Eq("DataType", dt));
            if (variableName != "")
                criterions.Add(Restrictions.Like("Number", variableName, MatchMode.Anywhere));
            var pointList = Instance().Query<Variable>(criterions, null, 0, 0);

            return pointList;
        }


        public IList<Variable> SearchVariableBySama(int variableType = -1, string variableName = "")
        {
            var criterions = new List<AbstractCriterion>();

            if (variableType != -1)
                criterions.Add(Restrictions.Eq("VariableType", (VariableType)variableType));

            if (!string.IsNullOrEmpty(variableName))
                criterions.Add(Restrictions.Like("Number", variableName, MatchMode.Anywhere));

            var variableList = Instance().Query<Variable>(criterions, null, 0, 0);
            return variableList;
        }


        public int GetMaxAddress(long iOUnitID)
        {
            var criterions = new List<AbstractCriterion>();
            criterions.Add(Restrictions.Eq("IOUnit.ID", iOUnitID));
            var list = Instance().Query<Variable>(criterions, null, 0, 0);
            if (null != list && list.Count > 0)
            {
                var maxAddress = list.Max(v => v.Address);
                return maxAddress;
            }
            return 0;
        }

    }
}
