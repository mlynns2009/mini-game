using Godot;

public partial class MainMenu : Control
{
   

	public override void _Ready()
	{
		ProcessMode = ProcessModeEnum.Always;


		GetNode<Button>("Panel/VBoxContainer/StartButton").Pressed += OnStartPressed;
		GetNode<Button>("Panel/VBoxContainer/PauseButton").Pressed += OnPausePressed;
		GetNode<Button>("Panel/VBoxContainer/QuitButton").Pressed += OnQuitPressed;
	}

	private void OnPausePressed()
	{
		var tree = GetTree();
		tree.Paused = !tree.Paused;


		// Optional: show menu only when paused
		Visible = tree.Paused;
	}

	private void OnStartPressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("res://Scenes/Level.tscn");
	}

	private void OnQuitPressed()
	{
		GetTree().Quit();
	}
}
