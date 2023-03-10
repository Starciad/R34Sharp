using System.Xml;
using System.Xml.Serialization;

namespace R34Sharp
{
    /// <summary>
    /// Represents a collection of Rule34 tags.
    /// </summary>
    [XmlRoot(ElementName = "tags")]
    public class R34Tags : R34Data
    {
        /// <summary>
        /// The collection of Rule34 tags.
        /// </summary>
        [XmlElement(ElementName = "tag")] public R34Tag[] Data { get; set; }

        /// <summary>
        /// The collection type.
        /// </summary>
        [XmlAttribute(AttributeName = "type")] public string Type { get; set; }

        internal override async Task BuildAsync(R34ApiClient instance)
        {
            try
            {
                if (Data == null)
                    return;

                await Parallel.ForEachAsync(Data, new Func<R34Tag, CancellationToken, ValueTask>(async (current, token) =>
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
