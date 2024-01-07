using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutCompenents;

public class _LayoutNavBarComponentPartial : ViewComponent
{
	public IViewComponentResult Invoke()
	{
		return View();
	}
}
