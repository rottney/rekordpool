# rekordpool
<p>
    <a href="./Pool/Index">Pool</a> page contains a collective track list.  
    You must 
    <a asp-area="Identity" asp-page="/Account/Register">create an account</a>
     and 
    <a asp-area="Identity" asp-page="/Account/Login">log in</a>
     to use this feature to view or add tracks.
</p>

<p>
    Please see the following images for the basic upload flow:
</p>

<p>
    <b>1:</b><br>
    <img style="padding: 10px;" src="~/step1.jpg" width="796" height="307" alt="Step 1"><hr>
    <b>2:</b><br>
    <img style="padding: 10px;" src="~/step2.jpg" width="585" height="334" alt="Step 2"><hr>
    <b>3:</b><br>
    <img style="padding: 10px;" src="~/step3.jpg" width="367" height="283" alt="Step 3"><hr>
    <b>4:</b><br>
    <img style="padding: 10px;" src="~/step4.jpg" width="366" height="381" alt="Step 4"><hr>
    <b>5:</b><br>
    <img style="padding: 10px;" src="~/step5.jpg" width="593" height="286" alt="Step 5">
    
    <br>
    Artist and Track names will be auto-populated from the provided link.

    <br>
    You may only delete tracks that you have added.

    <br>
    <b>Note:</b>  Only single tracks are supported - album or playlist links will be rejected.

    <br>
    <b>Note:</b>  If you do not provide a vaid SoundCloud mini embed link,  
    or you provide a link to a song which already exists in the database,
    nothing will be added and you will automatically be returned to the collective list.
</p>

<p>
    *Note:*  Mobile devices are not supported at this time.

    <br>
    <b>Coming Soon:</b>  Support for Spotify links!
</p>

<p>
    If you encounter any problems, please 
    <a href="https://github.com/rottney/rekordpool/issues/new", target="_blank">raise an issue</a>!
</p>
