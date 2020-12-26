using Northwoods.Go;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Choice;
using System;

namespace Sinowyde.DOP.PIDBlock.Choice
{
    ///<summary>
    /// ��Сֵ�㷨�飨MIN
    /// </summary>
    [Serializable]
    public class MinBlock : PIDGeneralBlock
    {
        public MinBlock()
            : base(new PIDMin())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamMin();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "choice_min_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
        /// <summary>
        /// ������Ҫ�����ܽ���Ҫ����
        /// </summary>
        /// <returns></returns>
        public override bool CheckSelfValid()
        {
            bool isValid = base.CheckSelfValid();
            int count = 0;
            for (int j = 0; j < this.LeftPortsCount; j++)
            {
                GoGeneralNodePort leftPort = this.GetLeftPort(j);
                if (leftPort.LinksCount > 0)
                {
                    count++;
                }
            }
            if (count < 2)
            {
                //���ɴ����¼
                PIDCompileErrManager.Instance().AddError(new PIDCompileError
                {
                    Identity = this.Identity,
                    GroupIndex = this.Algorithm.GroupIndex,
                    IndexInGroup = this.Algorithm.IndexInGroup,
                    Description = string.Format("Min�㷨��������Ҫ��������ܽ�����"),
                    AlgName = this.Algorithm.AlgName
                });
                isValid = false;
            }

            return isValid;
        }
    }
}