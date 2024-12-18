using Android.Content;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using Android.Graphics;

namespace DotTask
{
    public class TaskAdapter : BaseAdapter<TaskItem>
    {
        private readonly Context context;
        private readonly List<TaskItem> taskList;

        public TaskAdapter(Context context, List<TaskItem> tasks)
        {
            this.context = context;
            this.taskList = tasks;
        }

        public override TaskItem this[int position] => taskList[position];

        public override int Count => taskList.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = taskList[position];
            View view = convertView ?? LayoutInflater.From(context).Inflate(Resource.Layout.task_item, null);

            var checkBox = view.FindViewById<CheckBox>(Resource.Id.taskCheckBox);
            var textView = view.FindViewById<TextView>(Resource.Id.taskTitle);

            textView.Text = item.Title;
            checkBox.Checked = item.IsCompleted;

            checkBox.Click += (sender, e) =>
            {
                item.IsCompleted = checkBox.Checked;
                taskAdapter.NotifyDataSetChanged();
            };

            // Strike-through text if completed
            textView.PaintFlags = item.IsCompleted
                ? textView.PaintFlags | PaintFlags.StrikeThruText
                : textView.PaintFlags & ~PaintFlags.StrikeThruText;

            return view;
        }
    }
}
