<?php
include_once 'db.php';

$username_p = mysqli_real_escape_string($conn, $_POST["Username"]);
$password_p = mysqli_real_escape_string($conn, $_POST["Password"]);

// Check if the username already exists in Login table
$sql = "SELECT * FROM Login WHERE `Username` = '$username_p'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    echo "Ce nom d'utilisateur existe déjà.";
} else {
    // Insert new user into Login table
    $sql = "INSERT INTO Login (`Username`, `Password`) VALUES ('$username_p' , MD5('$password_p'))";
    
    if ($conn->query($sql) === TRUE) {
        // Get the ID of the newly inserted user
        $user_id = $conn->insert_id;
        
        // Insert user ID and role into Role table
        $role = "student"; // Set initial role to "student"
        $sql = "INSERT INTO Role (`ID`, `role`) VALUES ('$user_id' , '$role')";
        
        if ($conn->query($sql) === TRUE) {
            echo "Enregistrement effectué avec succès.";
        } else {
            echo "Error: " . $sql . "<br>" . $conn->error;
        }
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }
}

$conn->close();
?>
