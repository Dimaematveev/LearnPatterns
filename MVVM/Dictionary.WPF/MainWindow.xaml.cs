using DataBase.BL;
using Dictionary.BL;
using Dictionary.BL.EditAdd;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Dictionary.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApplicationViewModel applicationViewModel = new ApplicationViewModel();
            List<Relation> ListRelations = new List<Relation>
            {
                new Relation(
                                "Название таблиц",
                                new ViewDictionary.GadgetControl(),
                                new Func<object, IEditAddViewWindows>((W) => (new EditAdd.GadgetWindows((Dic_DeviceGadget) W))),
                                applicationViewModel.Db.DeviceGadgets,
                                new Func<object>(()=> new Dic_DeviceGadget())
                            ),
                new Relation(
                                "Типы устройств",
                                new ViewDictionary.TypeControl(),
                                new Func<object, IEditAddViewWindows>((W) => new EditAdd.TypeWindows((Dic_DeviceType)W, applicationViewModel.ApplicationListDevice.DeviceGadgets)),
                                applicationViewModel.Db.DeviceTypes,
                                new Func<object>(()=> new Dic_DeviceType())
                            ),
                new Relation(
                                "Модели устройств",
                                new ViewDictionary.ModelControl(),
                                new Func<object, IEditAddViewWindows>((W) =>  (new EditAdd.ModelWindows((Dic_DeviceModel)W, applicationViewModel.ApplicationListDevice.DeviceTypes))),
                                applicationViewModel.Db.DeviceModels,
                                new Func<object>(()=> new Dic_DeviceModel())
                            ),
                new Relation(
                                "Местоположение",
                                new ViewDictionary.LocationControl(),
                                new Func<object, IEditAddViewWindows>((W) => new EditAdd.LocationWindows((Dic_DeviceLocation)W)),
                                applicationViewModel.Db.DeviceLocations,
                                new Func<object>(()=> new Dic_DeviceLocation())
                            ),
                new Relation(
                                "СП и СИ",
                                new ViewDictionary.Sp_SiControl(),
                                new Func<object, IEditAddViewWindows>((W) => new EditAdd.Sp_SiWindows((Dic_DeviceSp_Si)W)),
                                applicationViewModel.Db.DeviceSp_Si,
                                new Func<object>(()=> new Dic_DeviceSp_Si())
                            ),
            };
            applicationViewModel.SetListRelations(ListRelations);
            this.DataContext = applicationViewModel;
        }


    }
}
