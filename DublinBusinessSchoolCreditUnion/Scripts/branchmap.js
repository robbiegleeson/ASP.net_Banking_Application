function Initialize() {
    var mapCanvas = document.getElementById('canvas');
    var mapOptions = {
        center: new google.maps.LatLng(53.3376983, -6.2571452),
        zoom: 12,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }
    var map = new google.maps.Map(mapCanvas, mapOptions)

    var hOfficeMarker = new google.maps.Marker({
        position: new google.maps.LatLng(53.340524, -6.2655232),
        map: map,
        title: 'Head Office'
    });

    var fairviewMarker = new google.maps.Marker({
        position: new google.maps.LatLng(53.362665, -6.239475),
        map: map,
        title: 'Fairview'
    });

    var smithfieldMarker = new google.maps.Marker({
        position: new google.maps.LatLng(53.3484175, -6.2782218),
        map: map,
        title: 'Smithfield'
    });

    var georgesStMarker = new google.maps.Marker({
        position: new google.maps.LatLng(53.340524, -6.265523),
        map: map,
        title: 'Georges St'
    });

    var parnelStMarker = new google.maps.Marker({
        position: new google.maps.LatLng(53.350297, -6.26799),
        map: map,
        title: 'Parnell St'
    });
}
google.maps.event.addDomListener(window, 'load', Initialize);