using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.PIDAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDBlock.IO
{
    /// <summary>
    /// IO模块基类
    /// </summary>
    [Serializable]
    public class IOBlock : PIDGeneralBlock
    {
        public IOBlock(PIDBindAlgorithm algorithm)
            :base(algorithm)
        { 
        }

        protected override bool IsShowPortLabelName
        {
            get
            {
                return false;
            }
        }

        public override bool CheckSelfValid()
        {
            bool isValid = true;
            IList<PIDAlgorithmVar> inputs = this.Algorithm.GetAllInput();
            foreach (PIDAlgorithmVar input in inputs)
            {
                if (!string.IsNullOrEmpty(input.BindSource)
                    && !input.BindSource.StartsWith(BindSourceToken.PrefixBlock))
                {
                    IList<Variable> variables = DOPDataLogic.Instance().SearchVariableBySama(-1, input.BindSource);
                    if (variables == null || variables.Count == 0)
                    {
                        isValid = false;
                        //生成错误记录
                        PIDCompileErrManager.Instance().AddError(new PIDCompileError
                        {
                            Identity = this.Identity,
                            GroupIndex = this.Algorithm.GroupIndex,
                            IndexInGroup = this.Algorithm.IndexInGroup,
                            Description = string.Format("关联变量不存在"),
                            AlgName = this.Algorithm.AlgName
                        });
                    }
                }
            }
            return isValid && base.CheckSelfValid();
        }
    }
}
