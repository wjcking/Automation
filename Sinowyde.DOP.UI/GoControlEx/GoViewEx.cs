using System.Collections;
using Northwoods.Go;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.GoObjectEx;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Sinowyde.DOP.UI
{
    public class GoViewEx : GoView
    {
        private GoToolLinkingNewEx goToolLinkingNewEx = null;
        private GoToolRelinkingEx goToolRelinkingEx = null;


        public delegate void EventHandler();
        public event EventHandler ScaleChangedEvent;


        public override float DocScale
        {
            get
            {
                return base.DocScale;
            }
            set
            {

                base.DocScale = value;
                if (null != ScaleChangedEvent)
                    ScaleChangedEvent();
            }
        }

        public GoViewEx()
        {
            Dock = DockStyle.Fill;
            DragsRealtime = true; //拖动刷新
            CanEnabled(false);

            goToolRelinkingEx = new GoToolRelinkingEx(this);
            goToolLinkingNewEx = new GoToolLinkingNewEx(this);

            //NewGoLink = new BlockLink { LinkStyle = 0 };
            NewGoLabeledLink = new BlockLink { LinkStyle = 0 };

            this.ReplaceMouseTool(typeof(GoToolRelinking), goToolRelinkingEx);
            this.ReplaceMouseTool(typeof(GoToolLinkingNew), goToolLinkingNewEx);


            //Document.MaintainsPartID = true;
        }

        public virtual void ZoomIn()
        {
            this.DocScale = (float)(Math.Round(this.DocScale / 0.9f * 100) / 100);
        }

        public virtual void ZoomOut()
        {
            this.DocScale = (float)(Math.Round(this.DocScale * 0.9f * 100) / 100);
        }

        public virtual void Zoom(float docScale = 1)
        {
            this.DocScale = docScale;
        }


        public virtual void CanEnabled(bool flag)
        {
            Enabled = flag;
            BackColor = flag ? Color.White : Color.Gray;
        }

        private void SetLinkParams(GoSelectionEventArgs evt)
        {
            //重新连接   需要UnLink
            var linkNode = evt.GoObject as BlockLink;
            if (null == linkNode) return;

            var fromPort = linkNode.FromPort;
            var toPort = linkNode.ToPort;
            var fromNodePort = fromPort as GoGeneralNodePort;
            var toNodePort = toPort as GoGeneralNodePort;
            if (null != fromNodePort && null != toNodePort)
            {
                var algorithmVarFrom = fromNodePort.UserObject as PIDAlgorithmVar;
                var algorithmVarTo = toNodePort.UserObject as PIDAlgorithmVar;
                if (null != algorithmVarFrom && null != algorithmVarTo)
                {
                    if (!algorithmVarFrom.VarType.Equals(algorithmVarTo.VarType))//输入端口不能有两个输入   || toNodePort.LinksCount > 1 port上已经解决了
                        Document.Remove(linkNode);

                    else
                    {
                        linkNode.LinkStyle = algorithmVarFrom.VarType == PIDVarDataType.AM ? 1 : 0;

                        var generalBlockFrom = fromPort.Node as PIDGeneralBlock;
                        var generalBlockTo = toPort.Node as PIDGeneralBlock;
                        if (null != generalBlockFrom && null != generalBlockTo)
                        {
                            //2016 03 09 zza 改为编译时统一去做 暂时去掉
                            //var sourceVar = string.Format("{0}.{1}.{2}", BindSourceToken.PrefixBlock, generalBlockFrom.Identity, algorithmVarFrom.Name);
                            //generalBlockTo.Algorithm.BindParam(algorithmVarTo.Name, sourceVar);
                        }
                    }
                }
            }
        }

        protected override void OnLinkRelinked(GoSelectionEventArgs evt)
        {
            SetLinkParams(evt);
            base.OnLinkRelinked(evt);
        }

        protected override void OnLinkCreated(GoSelectionEventArgs evt)
        {
            SetLinkParams(evt);
            base.OnLinkCreated(evt);
        }


        protected override void OnSelectionCopied(EventArgs evt)
        {
            base.OnSelectionCopied(evt);
        }

        protected override void OnSelectionDeleting(System.ComponentModel.CancelEventArgs evt)
        {
            base.OnSelectionDeleting(evt);
        }

        protected override void OnSelectionDeleted(EventArgs evt)
        {
            base.OnSelectionDeleted(evt);
        }

        protected override void OnClipboardCopied(EventArgs evt)
        {
            base.OnClipboardCopied(evt);
        }

        protected override void OnClipboardPasted(EventArgs evt)
        {
            base.OnClipboardPasted(evt);
        }
    }
}
