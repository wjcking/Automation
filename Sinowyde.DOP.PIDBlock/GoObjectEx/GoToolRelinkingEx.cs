using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;
using Sinowyde.DOP.PIDAlgorithm;

namespace Sinowyde.DOP.PIDBlock.GoObjectEx
{
    [Serializable]
    public class GoToolRelinkingEx : GoToolRelinking
    {
        public GoToolRelinkingEx(GoView goView)
            : base(goView)
        {

        }

        public override void StartRelink(IGoLink oldlink, bool forwards, System.Drawing.PointF dc)
        {
            //这里取消连接关系即可
            var oldtoPort = oldlink.ToPort as GoGeneralNodePort;
            if (null != oldtoPort)
            {
                var algorithmVarTo = oldtoPort.UserObject as PIDAlgorithmVar;
                if (null != algorithmVarTo)
                {
                    var generalBlock = oldtoPort.Node as PIDGeneralBlock;
                    if (null != generalBlock)
                        generalBlock.Algorithm.UnBindParam(algorithmVarTo.Name);
                }
            }
            base.StartRelink(oldlink, forwards, dc);
        }
    }
}
