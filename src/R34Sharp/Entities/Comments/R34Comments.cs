using System.Xml;
using System.Xml.Serialization;

namespace R34Sharp
{
    /// <summary>
    /// Represents a collection of Rule34 Comments.
    /// </summary>
    [XmlRoot(ElementName = "comments")]
    public class R34Comments : R34Data
    {
        /// <summary>
        /// The collection of Rule34 comments.
        /// </summary>
        [XmlElement(ElementName = "comment")] public R34Comment[] Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute(AttributeName = "type")] public string Type { get; set; }

        /// <summary>
        /// The count of comments present in this collection.
        /// </summary>
        [XmlIgnore] public ulong Count => (ulong)Data.Length;

        internal override async Task BuildAsync(R34ApiClient instance)
        {
            try
            {
                if (Data == null)
                    return;

                await Parallel.ForEachAsync(Data, new Func<R34Comment, CancellationToken, ValueTask>(async (current, token) =>
                {
                    await current.BuildAsync(instance);
                }));
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }

            await Task.CompletedTask;
        }
    }
}
