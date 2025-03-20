[HttpPost]
public async Task<IActionResult> Sample ([FromBody] Sample model)
{
    if (model == null)
        return Json(new { success = false, message = "請填寫完整。" });
    if (!ModelState.IsValid)
    {
        // 收集所有的驗證錯誤訊息
        var errorMessages = ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();
        // 返回驗證錯誤訊息，如果有多項錯誤使用<br/>串接，前端肉眼會看到換行效果
        return Json(new { success = false, message = string.Join("<br/>", errorMessages) });
    }
    try
    {
        // 執行資料庫邏輯
        return Json(new { success = true });
    }
    catch (Exception)
    {
        return Json(new { success = false, message = "系統有誤，請稍後再試。" });
    }

}
