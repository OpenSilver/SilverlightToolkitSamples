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
            var runtime = new UnmarshalledJavaScriptExecutionHandler(JSRuntime);
            Cshtml5Initializer.Initialize(runtime);
            Program.RunApplication();
        }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }
    }
}