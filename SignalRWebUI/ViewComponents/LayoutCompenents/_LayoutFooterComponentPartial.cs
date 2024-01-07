using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SignalRWebUI.ViewComponents.LayoutCompenents;

public class _LayoutFooterComponentPartial:ViewComponent
{
	public IViewComponentResult Invoke()
	{
		return View();
	}
}
