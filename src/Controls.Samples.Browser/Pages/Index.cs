using DotNetForHtml5;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System.Windows.Controls.Samples.Browser.Interop;
using System.Threading.Tasks;

namespace System.Windows.Controls.Samples.Browser.Pages
{
    [Route("/")]
    public class Index : ComponentBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder __builder)
        {
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (!await JSRuntime.InvokeAsync<bool>("getOSFilesLoadedPromise"))
            {
                throw new InvalidOperationException("Failed to initialize OpenSilver. Check your browser's console for error details.");
            }

            var runtime = new UnmarshalledJavaScriptExecutionHandler(JSRuntime);
            Cshtml5Initializer.Initialize(runtime);
            Program.RunApplication();
        }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }
    }
}