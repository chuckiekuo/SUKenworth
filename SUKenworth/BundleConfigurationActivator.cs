using System.Web.Optimization;

[assembly: WebActivator.PostApplicationStartMethod(typeof(SUKenworth.BundleConfigurationActivator), "Activate")]
namespace SUKenworth
{
    public static class BundleConfigurationActivator
    {
        public static void Activate()
        {
            BundleTable.Bundles.RegisterConfigurationBundles();
        }
    }
}