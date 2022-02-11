using Tizen.Flutter.Embedding;
using Tizen.System;

namespace Runner
{
    public class App : FlutterApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();

            GeneratedPluginRegistrant.RegisterPlugins(this);

            var channel = new MethodChannel("csharp_plugin");
            channel.SetMethodCallHandler(async (call) =>
            {
                if (call.Method == "getPlatformVersion")
                {
                    if (Information.TryGetValue("http://tizen.org/feature/platform.version", out string version))
                    {
                        return version;
                    }
                    else
                    {
                        throw new FlutterException("error", "Failed to get platform version.", null);
                    }
                }
                throw new MissingPluginException();
            });
        }

        static void Main(string[] args)
        {
            var app = new App();
            app.Run(args);
        }
    }
}
