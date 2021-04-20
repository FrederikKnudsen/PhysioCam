using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam
{
    [ContentProperty(nameof(Source))]
    class EmbeddedImageRessource : IMarkupExtension

    {
        public string Source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Source))
            {
                return null;
            }

            var imageSource = ImageSource.FromResource(Source, typeof(EmbeddedImageRessource).GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}
