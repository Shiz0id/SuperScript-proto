# SuperScript

SuperScript is a Windows Forms prototype for running a small, local file-automation
script. It is intentionally limited to the commands implemented by
`WinFormsApp1/ScriptEng.cs`; it is not intended to be a general-purpose scripting
language or a background automation service.

## Supported commands

Scripts contain one command per line:

```text
DO RUN_PROCESS("C:\Tools\backup.exe", "--quick")
DO MOVE_FILE("C:\Inbox\report.txt", "C:\Archive\report.txt")
DO DELETE_FILE("C:\Inbox\old.txt")
WHEN FILE_DETECTED("C:\Inbox\*.txt")
```

- `DO RUN_PROCESS` starts an existing executable with the supplied argument string.
- `DO MOVE_FILE` moves a file to the supplied destination.
- `DO DELETE_FILE` deletes a file.
- `WHEN FILE_DETECTED` watches the directory and filename pattern and reports newly
  created matching files to the console.

Commands are matched case-insensitively. Unsupported or malformed lines are
ignored. A file-detection trigger only reports the detected path; it does not run
another command.

## Scope and limitations

- The prototype targets Windows and .NET 8.
- Scripts are executed locally with the permissions of the current user.
- There is no scheduling, branching, variable substitution, networking, or
  persistence.
- File watchers remain active until `ScriptEngine.Stop()` is called or the process
  exits.
- The current Windows Forms UI provides file and process helpers, including
  an explicit RunAsAdmin action; script editing and the script engine are
  separate prototype components.

This deliberately narrow scope keeps the repository useful as a prototype while
making the current behavior explicit. New commands should be added only when
their syntax and execution behavior can be documented here.