namespace BitCalculator.Controllers
{
    using System.Web.Mvc;
    using Models;

    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var calcModel = new CalcModel();
            calcModel.Modifier = 0;
            calcModel.Quantity = 1;

            return View(calcModel);
        }

        [HttpPost]
        public ActionResult Index(int Quantity, string Type)
        {
            var calcModel = new CalcModel();
            calcModel.Quantity = Quantity;

            switch (Type)
            {
                case "b":
                    calcModel.Modifier = 0;
                    break;
                case "B":
                    calcModel.Modifier = 3;
                    break;
                case "Kb":
                    calcModel.Modifier = 10;
                    break;
                case "KB":
                    calcModel.Modifier = 13;
                    break;
                case "Mb":
                    calcModel.Modifier = 20;
                    break;
                case "MB":
                    calcModel.Modifier = 23;
                    break;
                case "Gb":
                    calcModel.Modifier = 30;
                    break;
                case "GB":
                    calcModel.Modifier = 33;
                    break;
                case "Tb":
                    calcModel.Modifier = 40;
                    break;
                case "TB":
                    calcModel.Modifier = 43;
                    break;
                case "Pb":
                    calcModel.Modifier = 50;
                    break;
                case "PB":
                    calcModel.Modifier = 53;
                    break;
                case "Eb":
                    calcModel.Modifier = 60;
                    break;
                case "EB":
                    calcModel.Modifier = 63;
                    break;
                case "Zb":
                    calcModel.Modifier = 70;
                    break;
                case "ZB":
                    calcModel.Modifier = 73;
                    break;
                case "Yb":
                    calcModel.Modifier = 80;
                    break;
                case "YB":
                    calcModel.Modifier = 83;
                    break;
            }

            return View(calcModel);
        }
    }
}