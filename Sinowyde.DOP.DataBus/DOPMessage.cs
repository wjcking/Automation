using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.DataBus
{
    /// <summary>
    /// DOP消息类型
    /// </summary>
    public class DOPMessage
    {
        /// <summary>
        /// 消息主题
        /// </summary>
        public string Topic
        {
            get;
            set;
        }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content
        {
            get;
            set;
        }
        /// <summary>
        /// 序列化消息
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Topic: {0}, Content: {1}", this.Topic, this.Content);
        }
        /// <summary>
        /// 饭序列化
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DOPMessage FromString(string message)
        {
            try
            {
                string[] parts = message.Trim().Split(',');
                return new DOPMessage
                {
                    Topic = parts[0].Trim().Substring("Topic: ".Length),
                    Content = parts[1].Trim().Substring("Content: ".Length)
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
