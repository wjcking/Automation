using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDBlock
{
    [Serializable]
    public class BaseTool<T> : IToolBlock
        where T : PIDGeneralBlock
    {
        public virtual PIDGeneralBlock CreateBlock()
        {
            PIDGeneralBlock block = System.Activator.CreateInstance<T>();
            //block.InitBlockAndDraw(string.Empty);
            return block;
        }

        public virtual PIDGeneralBlock CreateBlockForXml()
        {
            PIDGeneralBlock block = System.Activator.CreateInstance<T>();
            //block.InitBlock(string.Empty);
            return block;
        }
    }
}
