extends SubViewportContainer

@onready var original_size := size
@onready var original_position := position 

func _on_view_size_changed():
	var new_viewport_size = get_tree().root.size
	if new_viewport_size > Vector2i(854, 512):
		size = new_viewport_size
		global_position = Vector2.ZERO
	else:
		size = original_size
		position = original_position

func _ready() -> void:
	get_tree().root.size_changed.connect(_on_view_size_changed)
