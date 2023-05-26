function toggleContent(section) {
    // Toggle button active state
    var missionBtn = document.getElementById('missionBtn');
    var brewingBtn = document.getElementById('brewingBtn');

    if (section === 'mission') {
        missionBtn.classList.add('active');
        brewingBtn.classList.remove('active');

        // Show Mission and Values content
        document.getElementById('missionContent').style.display = 'block';
        document.getElementById('brewingContent').style.display = 'none';
    } else if (section === 'brewing') {
        brewingBtn.classList.add('active');
        missionBtn.classList.remove('active');

        // Show Brewing Process content
        document.getElementById('brewingContent').style.display = 'block';
        document.getElementById('missionContent').style.display = 'none';
    }
}
