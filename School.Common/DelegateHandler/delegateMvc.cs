using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Common.DelegateHandler
{
    /*
    public class delegateMvc
    {
        // declare a delegate for the bookpricechanged event
        public delegate void BookPriceChangedHandler(object sender,BookPriceChangedEventArgs e);

        // declare the bookpricechanged event using the bookpricechangeddelegate
        public event BookPriceChangedHandler BookPriceChanged;

        // instance variable for book price
        object _bookPrice;

        // property for book price
        public object BookPrice
        {
            set
            {
                // set the instance variable
                _bookPrice = value;

                // the price changed so fire the event!
                OnBookPriceChanged();
            }
        }

        // method to fire price canged event delegate with proper name
        // this is the method our observers should be implenting!
        protected void OnBookPriceChanged()
        {
            BookPriceChanged(this, new BookPriceChangedEventArgs(_bookPrice));
        }
    }


public class MyCommand<T>{

Action myAction;
Func<T, bool> canExecute;

public MyCommand(Action<T> actionToBeExecuted, Func<T, bool> canExecute)
{
this.myAction = actionToBeExecuted;
this.canExecute = canExecute;
}

public void ExecuteMyCommand<T>(T param)
{
if(this.canExecute(param))
   this.myAction(param);
}
}

    */
}
