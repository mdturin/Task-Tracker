using Task_Tracker.commands;

var command = new LoadAllTasksCommand();
command.Execute(new Task_Tracker.models.DynamicItem());