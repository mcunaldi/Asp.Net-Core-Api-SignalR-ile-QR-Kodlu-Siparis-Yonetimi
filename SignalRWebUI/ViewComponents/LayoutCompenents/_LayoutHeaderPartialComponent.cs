using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutCompenents;

public class _LayoutHeaderPartialComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
