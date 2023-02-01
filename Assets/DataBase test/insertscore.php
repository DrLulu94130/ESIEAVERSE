<?php

include_once 'db.php';

$score_p = $_POST["score"];

$sql = "INSERT INTO Scores (score)
VALUES ($score_p)";

if ($conn->query($sql) === TRUE) {

    $sql2 = "SELECT MAX (score) AS MaxScore FROM Scores";
    $result = mysqli_query($conn, $sql2);
    $data = mysqli_fetch_assoc($result);
    echo $data['MaxScore'];
    
} else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}

$conn->close();
?>