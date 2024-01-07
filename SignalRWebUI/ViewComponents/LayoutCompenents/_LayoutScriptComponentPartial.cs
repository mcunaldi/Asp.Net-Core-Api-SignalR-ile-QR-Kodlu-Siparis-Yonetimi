using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutCompenents;

public class _LayoutScriptComponentPartial:ViewComponent
{
	public IViewComponentResult Invoke()
	{
		return View();
	}
}
