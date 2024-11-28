using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NailWarehouse.Models;
using NailWarehouse.Web.Controllers.Helpers;
using NailWarehouse.Web.Models;

namespace NailWarehouse.Web.Controllers
{
    /// <summary>
    /// Методы для работы с основными страницами
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Загрузка главной страницы
        /// </summary>
        public async Task<IActionResult> Index()
        {
            StaticAppModel.SelectedNailId = Guid.Empty;

            var stats = await StaticAppModel.NailManager.GetStatsAsync();
            var result = new IndexModel()
            {
                FullCount = stats.FullCount,
                FullSumNoTax = stats.FullSummaryNoTax,
                FullSumWTax = stats.FullSummaryWithTax,

                DataList = await StaticAppModel.NailManager.GetAllAsync(),
            };

            return View("Index", result);
        }

        #region NailEdit

        /// <summary>
        /// Загрузка страницы редактирования со стандартными данными
        /// </summary>
        [HttpGet]
        public ViewResult NailCreate()
        {
            return View("NailEdit", Converters.ToValidatableNail(DataGenerator.GetDefaultNail()));
        }

        /// <summary>
        /// Загрузка страницы редактирования с данными выбранного гвоздя
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> NailEdit()
        {
            return View("NailEdit", Converters.ToValidatableNail(await StaticAppModel.NailManager.GetNailByIdAsync(StaticAppModel.SelectedNailId)));
        }

        /// <summary>
        /// Выход из редактирования гвоздя
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> NailEdit(ValidatableNail validNail)
        {
            if (ModelState.IsValid)
            {
                if (await StaticAppModel.NailManager.GetNailByIdAsync(validNail.Id) == null)
                {
                    await StaticAppModel.NailManager.AddAsync(Converters.ToNail(validNail));
                }
                else
                {
                    await StaticAppModel.NailManager.EditAsync(Converters.ToNail(validNail));
                }
                await Index();
                Response.Redirect("/");
                return View("Index");
            }
            else
            {
                return View("NailEdit", validNail);
            }
        }

        #endregion

        #region Actions with no views of their own

        /// <summary>
        /// Удалить гвоздь из базы данных
        /// </summary>+
        [HttpDelete]
        public async Task<IActionResult> DeleteNail()
        {
            await StaticAppModel.NailManager.DeleteAsync(StaticAppModel.SelectedNailId);
            return await Index();
        }

        /// <summary>
        /// Выбрать гвоздь
        /// </summary>
        [HttpPost]
        public void SelectNail(Guid id)
        {
            StaticAppModel.SelectedNailId = id;
        }

        #endregion

        /// <summary>
        /// Загрузка страницы справки
        /// </summary>
        public IActionResult HelpPage()
        {
            return View();
        }

        /// <summary>
        /// Загрузка страницы ошибки
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
