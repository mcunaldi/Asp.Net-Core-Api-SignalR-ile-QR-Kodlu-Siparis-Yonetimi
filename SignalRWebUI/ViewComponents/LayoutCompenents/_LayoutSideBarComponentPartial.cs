using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutCompenents;

public class _LayoutSideBarComponentPartial : ViewComponent
{
	public IViewComponentResult Invoke()
	{
		return View();
	}
}
