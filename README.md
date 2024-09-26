# Task Tracker Console App [RoadMap](https://roadmap.sh/projects/task-tracker)

## Overview
The **Task Tracker Console App** is a simple command-line interface (CLI) application for managing tasks. It allows users to add, update, delete, mark tasks as in-progress or done, and list all tasks. The app supports customization for storing task data, allowing users to configure a custom directory for task storage or defaulting to a temporary folder if no configuration is provided.

## Features
- **Add**: Add new tasks via the CLI.
- **Update**: Update existing tasks.
- **Delete**: Remove tasks.
- **Mark In-progress**: Mark tasks as in-progress.
- **Mark Done**: Mark tasks as completed.
- **List**: List all tasks.


## Direct Running the Task Tracker Console App (Windows) 

You can directly run the Task Tracker Console App using the published build file. Follow these steps to get started:

### 1. Clone the repository:
```
git clone https://github.com/mdturin/Task-Tracker.git
```
### 2. Navigate to the project directory:
```
cd task-tracker
```
### 3. Add the `run` folder to the environment variable `PATH`:
After building the project, the compiled files are stored in the `run` folder. To run the app from anywhere, you need to add this folder to your system's `PATH` environment variable.
-   **Windows**:
    1.  Open System Properties → Advanced → Environment Variables.
    2.  Under `System variables`, find the `Path` variable, select it, and click `Edit`.
    3.  Click `New` and add the path to the `run` folder (e.g., `C:\path\to\task-tracker\run`).
    4.  Click `OK` to save the changes.

### 4. Run the Task Tracker App using the CLI:
Once you've added the path, you can run the `task-cli` commands directly from your terminal or command prompt.
```
task-cli add "new task"
```
This command will persist the new task in the JSON file as per the configuration.
Enjoy using the Task Tracker Console App!

## Configuration
You can customize the directory where the tasks are stored by providing a configuration file. The app will look for the configuration file at:	```C:\AppStore\appconfig.json```

## Sample appconfig.json
	{
	  "StorePath": "D:\\MyTaskStore\\",
	  "FileName": "tasks.json"
	}
	
- `StorePath`: The directory where tasks should be stored.
- `FileName`: The name of the file in which tasks will be saved.

## Default Configuration
If the config file is not set up, the app will default to storing tasks in the system's temporary folder (`%TEMP%` on Windows).

## Usage
Here are the available commands you can run:
- **Add a new task**:
	```
	task-cli add "Task Description"
	```
- **Update a task**:
	```
	task-cli update <task-id> "Updated Description"
	```
- **Delete a task**:
	```
	task-cli delete <task-id>
	```
- **Mark a task as in-progress**:
	```
	task-cli mark-in-progress <task-id>
	```
- **Mark a task as done**:
	```
	task-cli mark-done <task-id>`
	```
- **List all tasks**:
	```
	task-cli list
	task-cli list done
	task-cli list todo
	task-cli list in-progress
	```
## Contributing
Feel free to submit pull requests or report issues on the [GitHub repository](https://github.com/mdturin/Task-Tracker).

## License
This project is licensed under the MIT License.
