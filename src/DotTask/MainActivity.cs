using Android.App;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;

namespace DotTask
{
    [Activity(Label = "DotTask", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private List<TaskItem> taskList;
        private TaskAdapter taskAdapter;
        private EditText taskInput;
        private Button addTaskButton;
        private ListView taskListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            taskList = new List<TaskItem>();
            taskAdapter = new TaskAdapter(this, taskList);

            taskInput = FindViewById<EditText>(Resource.Id.taskInput);
            addTaskButton = FindViewById<Button>(Resource.Id.addTaskButton);
            taskListView = FindViewById<ListView>(Resource.Id.taskListView);

            taskListView.Adapter = taskAdapter;

            addTaskButton.Click += (sender, e) =>
            {
                var taskTitle = taskInput.Text;
                if (!string.IsNullOrWhiteSpace(taskTitle))
                {
                    var newTask = new TaskItem(taskTitle);
                    taskList.Add(newTask);
                    taskAdapter.NotifyDataSetChanged();
                    taskInput.Text = string.Empty;
                }
                else
                {
                    Toast.MakeText(this, "Please enter a task!", ToastLength.Short).Show();
                }
            };

            taskListView.ItemClick += (sender, e) =>
            {
                var task = taskList[e.Position];
                task.IsCompleted = !task.IsCompleted;  // Toggle completion
                taskAdapter.NotifyDataSetChanged();    // Refresh list view
            };
        }
    }
}
