using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RevitAPITrainingTsk53
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            // имя вкладки   в ревит
            string tabName = "revit API Training Task5.3";
            // создание вкладки
            application.CreateRibbonTab(tabName);

            //Путь к папке с приложением

            string utilsFolderPath = @"D:\RevitAPITrainig\";


            // создание панели

            var panel = application.CreateRibbonPanel(tabName, "Задание 5.3");

            //Создание кнопки

            var button1 = new PushButtonData("Система1", "Кнопки со свойствами",
                Path.Combine(utilsFolderPath, "RevitAPITrainingTsk51.dll"),
                "RevitAPITrainingTsk51.Main");
            var button2 = new PushButtonData("Система2", "Смена типов стен",
                Path.Combine(utilsFolderPath, "RevitAPITrainingTSk52.dll"),
                "RevitAPITrainingTSk52.Main");


            //Изображение для кнопки
            Uri uriImage1 = new Uri(@"D:\Учеба 2021\M3 tsks\T5\Tsk\RevitAPITrainingTsk53\RevitAPITrainingTsk53\Images\Proper.jpg", UriKind.Absolute);
            BitmapImage largeImage1 = new BitmapImage(uriImage1);
            button1.LargeImage = largeImage1;
            Uri uriImage2 = new Uri(@"D:\Учеба 2021\M3 tsks\T5\Tsk\RevitAPITrainingTsk53\RevitAPITrainingTsk53\Images\walls.jpg", UriKind.Absolute);
            BitmapImage largeImage2 = new BitmapImage(uriImage2);
            button2.LargeImage = largeImage2;


            //Добавление кнопки на панель

            panel.AddItem(button1);
            panel.AddItem(button2);

            return Result.Succeeded;
        }
    }
}
