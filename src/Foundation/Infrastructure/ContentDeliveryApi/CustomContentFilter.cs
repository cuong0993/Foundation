using EPiServer.ContentApi.Core.Serialization;
using EPiServer.Core;
using EPiServer.ServiceLocation;

namespace Foundation.Infrastructure.ContentDeliveryApi
{
    [ServiceConfiguration(typeof(IContentFilter), Lifecycle = ServiceInstanceScope.Singleton)]

    internal class CustomContentFilter : ContentFilter<IContent>
    {
        public override void Filter(IContent content, ConverterContext converterContext)
        {
            // content.Name = null;
        }
    }
}