using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SherNingFrameWork
{
    class EventsPractice
    {
        public static void Run()
        {
            Button button = new Button();
            Form form = new Form();

            button.Text = "Trigger";

            Builder johhny = new Builder("Johnny");
            johhny.BuilderEventHandler += delegate
            {
                Console.WriteLine("My name is : " + johhny.Name);
            };

            johhny.BuilderEventHandler += (sender, e) =>
                Console.WriteLine($"I am {e.State}, don't disturb me!");

            Builder bob = new Builder("Bob");
            bob.BuilderEventHandler += delegate
            {
                Console.WriteLine($"Hi, I am {bob.Name}");
            };

            button.Click += (s, e) => button.Text = "Invoked";

            // click is a trigger, drag is a trigger
            // when a trigger is detected, what action is accompanied? the method chained to the subscribed event is triggered
            button.Click += delegate
            {
                johhny.InvokeEvent();
                bob.InvokeEvent();
            };
            
            form.Controls.Add(button);
            Application.Run(form);
        }


        enum BuilderState { Building, Resting, Meeting }

        class BuilderEventArgs : EventArgs
        {
            public BuilderState State;
            public BuilderEventArgs(BuilderState state)
            {
                State = state;
            }
        }

        class Builder
        {
            public string Name { get; set; }
            public event EventHandler<BuilderEventArgs> BuilderEventHandler;

            public Builder(string name)
            {
                Name = name;
            }

            public void InvokeEvent()
            {
                BuilderEventArgs e = null;

                switch (new Random().Next(1,4))
                {
                    case 1:
                        e = new BuilderEventArgs(BuilderState.Building);
                        break;

                    case 2:
                        e = new BuilderEventArgs(BuilderState.Meeting);
                        break;

                    case 3:
                        e = new BuilderEventArgs(BuilderState.Resting);
                        break;
                }

                BuilderEventHandler?.Invoke(this, e);
            }
        }

    }

}
