﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using MyWarcraft.Models;
using MyWarcraft.Models.Events;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MyWarcraft.ViewModels
{
    public class ComponentViewModel : BindableBase
    {
        public ICommand Click { get; protected set; }
        public event ComponentSelected ComponentSelected;
        public int Life { get; set; }
        public Position Position { get; set; }

        public AbstractBuildable Component { get; set; }

        public ObservableCollection<BuildingCapabilityViewModel> BuildingCapabilitiesVMs { get; set; }
        public ObservableCollection<BuildingCapabilityViewModel> UnitsCapabilitiesVMs { get; set; }

        public ComponentViewModel(AbstractBuildable component)
        {
            Component = component;
            if (component.BuildingsCapabilities!=null)
            {
                BuildingCapabilitiesVMs = new ObservableCollection<BuildingCapabilityViewModel>();
                foreach (var capability in component.BuildingsCapabilities)
                {
                    var capabilityVM = new BuildingCapabilityViewModel(capability);
                    BuildingCapabilitiesVMs.Add(capabilityVM);
                }
            }
            if (component.UnitsCapabilities != null)
            {
                UnitsCapabilitiesVMs = new ObservableCollection<BuildingCapabilityViewModel>();
                foreach (var capability in component.UnitsCapabilities)
                {
                    var capabilityVM = new BuildingCapabilityViewModel(capability);
                    UnitsCapabilitiesVMs.Add(capabilityVM);
                }
            }
            Click = new DelegateCommand<ComponentViewModel>(OnComponentSelected);
        }

        private void OnComponentSelected(ComponentViewModel component)
        {
            if (ComponentSelected!=null)
            {
                ComponentSelected.Invoke(this, new ComponentSelectedEventArgs() { ComponentVM = this});
            }
        }
    }
}
