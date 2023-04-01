/*This script deals with opening the right link regarding a menu called library. Tester won't be able to acces moqt of those website as they link to private school resources. For the vision we have of the project each student is already loged in and can acces different resources via those link*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    public void OpenOurWebPage()
    {
        Application.OpenURL("http://pstesieaverse.alwaysdata.net/");
    }



    public void OpenCentreDeDocumentation()
    {
        Application.OpenURL("https://learning.esiea.fr/course/view.php?id=3353");
    }



    public void OpenBibliothequeNumerique()
    {
        Application.OpenURL("https://learning.esiea.fr/course/view.php?id=835");
    }



    public void OpenPresseEnLigne()
    {
        Application.OpenURL("https://learning.esiea.fr/course/view.php?id=4318");
    }



    public void OpenRick()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ&ab_channel=RickAstley");
    }
}
