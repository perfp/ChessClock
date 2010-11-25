using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace ChessClock
{
    public class ClockViewModel : PropertyChangedBase, IDisposable
    {
        readonly Timer _timer;
        public ClockViewModel()
        {            
            _timer = new Timer((state)=> UpdateHands(), null, 0, 1000);                        
        }

        private double _minuteHandAngle;
        private double _secondHandAngle;
        

        public void UpdateHands()
        {
            _minuteHandAngle = 360/60*DateTime.Now.Minute;
            _secondHandAngle = 360/60*DateTime.Now.Second;
           
            
           NotifyPropertyChanged("MinuteHandTransform");
           NotifyPropertyChanged("SecondHandTransform");
        }

        
        public CompositeTransform MinuteHandTransform
        {
            get {return new CompositeTransform{ Rotation = _minuteHandAngle};}
        }

        public CompositeTransform SecondHandTransform
        {
            get{
                return new CompositeTransform {Rotation = _secondHandAngle};
            }
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
