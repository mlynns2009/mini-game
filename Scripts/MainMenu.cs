using Godot;

public partial class MainMenu : Control
{
	public override void _Ready()
	{
		GD.Print("MAIN MENU READY");

		GetNode<Button>("Panel/VBoxContainer/StartButton").Pressed += OnStartPressed;
		GetNode<Button>("Panel/VBoxContainer/PauseButton").Pressed += OnPausePressed;
		GetNode<Button>("Panel/VBoxContainer/QuitButton").Pressed += OnQuitPressed;
	}

	private void OnStartPressed()
	{
		GD.Print("START CLICKED");
<<<<<<< Updated upstream
<<<<<<< Updated upstream
		var err = GetTree().ChangeSceneToFile("res://Scenes/Level.tscn");
=======
=======
>>>>>>> Stashed changes
		var err = GetTree().ChangeSceneToFile("res://Scenes/Level.tscn"); 
		GD.Print($"Scene change result: {err}");
>>>>>>> Stashed changes
	}

	private void OnPausePressed()
	{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
		GD.Print("PAUSE CLICKED");
		var err = GetTree().ChangeSceneToFile("res://Scenes/MainMenu.tscn");
=======
=======
>>>>>>> Stashed changes
		var tree = GetTree();
		tree.Paused = !tree.Paused;
		var err = GetTree().ChangeSceneToFile("res://Scenes/pause.tscn"); 
		Visible = tree.Paused;
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
	}
	
	private void OnQuitPressed()
	{
		GD.Print("QUIT CLICKED");
		GetTree().Quit();
	}
}
