const DPI = 300;
const DPI_MM = DPI / 25.4;
const devicePixelRatio = DPI_MM;

var i = 0;
function move() {
    //if (i === 0) {
        i = 1;
        var elem = document.getElementById("bar");
        var width = 1;
        var id = setInterval(frame, 20);
        function frame() {
            if (width >= 100) {
                clearInterval(id);
                i = 0;
            } else {
                width++;
                elem.style.width = width + "%";
            }
    }
    //}
}

function printJPG() {
    var mapTitle = $("#printTitle").val();
    var mapNo = "Map No: " + $("#mapNo").val();
    var mapComments = $("#mapComments").val();
    var mapSize = $("#printSize").text();
    //var mapScale = $("#printScale").val();
    var mapScale = $("#currentScale").text();
    var mapType = $("#printType option:selected").val();
    var mainTitle = $("#gaunpalika").val();
    draw(mapTitle, mapNo, mapComments, mapSize, mapScale, mapType, mainTitle);
    //let fullQuality = canvas1.toDataURL('image/jpeg', 1.0);
    var a = document.createElement('a');
    if (mapType == "png") {
        let fullQuality = canvas1.toDataURL('image/png', 1.0);
        a.href = fullQuality;
        a.download = 'out_image.png';
        document.body.appendChild(a);
        a.click();
    }
    else if (mapType == "jpeg") {
        let fullQuality = canvas1.toDataURL('image/jpeg', 1.0);
        a.href = fullQuality;
        a.download = 'out_image.jpg';
        document.body.appendChild(a);
        a.click();
    }
    else if (mapType == "pdf") {
        let outImage = canvas1.toDataURL('image/jpeg', 1.0);
        const pdf = new jspdf.jsPDF('landscape', 'mm', 'a4');
        pdf.addImage(outImage, 'JPEG', 0, 0, 297, 210);
        pdf.save('out_map.pdf');
    }
    var id = window.requestAnimationFrame(function () { });
    while (id--) {
        window.cancelAnimationFrame(id);
    }
    aniCheck = false;
}

function draw(mapTitle = "", mapNo = "", mapComments = "", mapSize = "", mapScale = "", mapType = "", mainTitle="") {
    var printBounds = $("#mapExtent").text().split(",");
    let rect = canvas1.getBoundingClientRect();
    canvas1.width = rect.width * devicePixelRatio;
    canvas1.height = rect.height * devicePixelRatio;
    let ctx = canvas1.getContext('2d');
    ctx.scale(devicePixelRatio, devicePixelRatio);

    // scale everything down using CSS
    canvas1.style.width = rect.width + 'px';
    canvas1.style.height = rect.height + 'px';

    //a4size
    ctx.beginPath();
    ctx.fillStyle = "white";
    ctx.fillRect(0, 0, 297, 210);
    ctx.fill();

    //image
    load_png();
    ctx.restore();
    let img = new Image();

    var link = document.getElementById('image-download');
    img.src = link.href;

    //img.src = mapCanvas.toDataURL('image/png',1.0);     
    ctx.drawImage(img, 12, 18, 225, 180);

    //Outer border
    ctx.fillStyle = "black";
    ctx.beginPath();
    ctx.moveTo(8, 14);
    ctx.lineTo(242, 14);
    ctx.lineTo(242, 202);
    ctx.lineTo(8, 202);
    ctx.closePath();
    ctx.strokeStyle = 'black'
    ctx.lineWidth = 0.8
    ctx.stroke();

    //map border
    ctx.beginPath();
    ctx.moveTo(12, 18);
    ctx.lineTo(237, 18);
    ctx.lineTo(237, 198);
    ctx.lineTo(12, 198);
    ctx.closePath();
    ctx.strokeStyle = 'black'
    ctx.lineWidth = 0.6
    ctx.stroke();

    //north arrow
    ctx.beginPath();
    ctx.moveTo(262, 25);
    ctx.lineTo(266, 14);
    ctx.lineTo(270, 25);
    ctx.lineTo(266, 21);
    ctx.closePath();
    ctx.strokeStyle = 'black'
    ctx.lineWidth = 0.8
    ctx.stroke();

    //Draw mapToptile
    let mapMainTitle = "";
    if (mainTitle != null && mainTitle != "" && mainTitle != "All")
    {
        mapMainTitle = mainTitle;
    }
    //let mapMainTitle = mapTitle;
    ctx.font = "bold 3.5px Arial";
    ctx.textAlign = "center";
    wrapText(ctx, mapMainTitle, 267, 31, 48, 4);
    //ctx.fillText(mapMainTitle, 267, 31);

    //Write scale
    //let mapscale = 10000
    let mapscale = mapScale
    ctx.font = "bold 2px Arial";
    ctx.textAlign = "center";
    let scaleToPrint = "";
    //if ($("#scaleSet").text() == "false") {
    //    scaleToPrint = "";
    //}
    if ($("#scaleLabel").is(":checked")) {
        scaleToPrint = '1:' + numberWithCommas(mapscale);
    }
    ctx.fillText(scaleToPrint, 266.5, 108);

    //Draw scalebar
    ctx.beginPath();
    ctx.moveTo(250, 104);
    ctx.lineTo(280, 104);
    ctx.lineTo(280, 105);
    ctx.lineTo(250, 105);
    ctx.closePath();
    ctx.strokeStyle = 'black'
    ctx.lineWidth = 0.2
    ctx.stroke();

    ctx.beginPath();
    ctx.lineWidth = "1";
    ctx.strokeStyle = "black";
    ctx.fillRect(250, 104, 5, 1);
    //ctx.stroke();

    ctx.beginPath();
    ctx.lineWidth = "1";
    ctx.strokeStyle = "black";
    ctx.fillRect(260, 104, 10, 1);
    ctx.stroke();

    //write scalebar text
    ctx.font = "2px Arial";
    ctx.textAlign = "center";
    let scaleText = '0'
    ctx.fillText(scaleText, 260, 103);

    ctx.font = "2px Arial";
    let scaleVal = mapscale * 10 / 1000000;
    scaleText = scaleVal.toFixed(2);
    ctx.fillText(scaleText, 270, 103);
    ctx.fillText(scaleText, 250, 103);

    scaleVal = mapscale * 20 / 1000000;
    ctx.textAlign = "left";
    scaleText = scaleVal.toFixed(2) + ' km';
    ctx.fillText(scaleText, 277, 103);

    // write projection parameters
    ctx.font = "italic 2px Arial";
    let crsSystem = 'Coordinate System: WGS1984 UTM Zone 44N'
    ctx.textAlign = "left";
    ctx.fillText(crsSystem, 246, 114);

    let crsPro = 'Projection: Traverse Mercator'
    ctx.textAlign = "left";
    ctx.fillText(crsPro, 246, 116.5);

    let crsDatum = 'Datum: WGS 1984'
    ctx.textAlign = "left";
    ctx.fillText(crsDatum, 246, 119);

    let crsEasting = 'False Easting: 500,000.0000'
    ctx.textAlign = "left";
    ctx.fillText(crsEasting, 246, 121.5);

    let crsNorthing = 'False Northing: 0.0000'
    ctx.textAlign = "left";
    ctx.fillText(crsNorthing, 246, 124.0);

    let crsMeridian = 'Central Meridian: 81.0000'
    ctx.textAlign = "left";
    ctx.fillText(crsMeridian, 246, 126.5);

    let crsScaleFactor = 'Scale Factor: 0.9996'
    ctx.textAlign = "left";
    ctx.fillText(crsScaleFactor, 246, 129);

    let crsOrigin = 'Latitude of Origin: 0.0000'
    ctx.textAlign = "left";
    ctx.fillText(crsOrigin, 246, 131.5);

    let crsUnit = 'Units: Meter'
    ctx.textAlign = "left";
    ctx.fillText(crsUnit, 246, 134);


    //map title
    ctx.beginPath();
    ctx.moveTo(245, 143);
    ctx.lineTo(292, 143);
    ctx.strokeStyle = 'Black'
    ctx.lineWidth = 0.4
    ctx.stroke();

    ctx.font = "3px Arial";
    //let maptitle = 'Map Showing Flood Details and the emabnkment heights of the Flood Asset manangement'
    ctx.textAlign = "left";
    wrapText(ctx, mapTitle, 246, 148, 48, 3.5);

    ctx.beginPath();
    ctx.moveTo(245, 160);
    ctx.lineTo(292, 160);
    ctx.strokeStyle = 'Black'
    ctx.lineWidth = 0.4
    ctx.stroke();

    //Map No
    ctx.font = "bold 4px Arial";
    //let mapNo = 'Map No: 01'
    ctx.textAlign = "center";
    ctx.fillText(mapNo, 266, 166);

    ctx.beginPath();
    ctx.moveTo(245, 170);
    ctx.lineTo(292, 170);
    ctx.strokeStyle = 'Black'
    ctx.lineWidth = 0.25
    ctx.stroke();

    //Map Notes
    ctx.font = "italic 2.5px Arial";
    //let MapNotes = 'Notes: This Map is prepared using Flood Asset Manangement System and provides the current status'
    ctx.textAlign = "left";
    wrapText(ctx, mapComments, 246, 174, 48, 3);
    //wrapText(ctx,MapNotes, 246, 174,48,3);

    //Map footer
    ctx.font = "italic 2px Arial";
    let Mapfooter = 'Printed using website: http://nwash.gov.np'
    ctx.fillStyle = "blue";
    ctx.textAlign = "left";
    ctx.fillText(Mapfooter, 8, 205);

    if ($("#mapGrid").is(":checked")) {
        var ymax;
        var xmin;

        var maxCo = proj4('EPSG:3857', 'EPSG:32644', [printBounds[2], printBounds[3]]);
        var minCo = proj4('EPSG:3857', 'EPSG:32644', [printBounds[0], printBounds[1]]);
        var ymax = Number(maxCo[1]);
        var xmin = Number(minCo[0]);


        //let topLeftX = 256671.5286;
        //let topLeftY = 3050369.2724;
        let topLeftX = xmin;
        let topLeftY = ymax;
        let graticuleSize = 50 * mapscale / 1000;
        let firstXMapDist = ((parseInt(topLeftX / graticuleSize) + 1) * graticuleSize - topLeftX);
        let firstXVal = Math.round(topLeftX + firstXMapDist);

        let firstX = 12 + firstXMapDist / mapscale * 1000;
        ctx.beginPath();
        ctx.moveTo(firstX, 18);
        ctx.lineTo(firstX, 198);
        ctx.strokeStyle = '#566573'
        ctx.lineWidth = 0.15
        ctx.stroke();
        ctx.fillStyle = "black";
        ctx.textAlign = "center";
        ctx.font = "2px Arial";
        ctx.fillText(firstXVal, firstX, 17);
        ctx.fillText(firstXVal, firstX, 200.5);

        while ((firstX + 50) < 237) {
            firstX = firstX + 50;
            firstXVal = firstXVal + graticuleSize;
            ctx.beginPath();
            ctx.moveTo(firstX, 18);
            ctx.lineTo(firstX, 198);
            ctx.strokeStyle = '#566573'
            ctx.stroke();
            ctx.fillText(Math.round(firstXVal), firstX, 17);
            ctx.fillText(Math.round(firstXVal), firstX, 200.5);
        }

        ctx.save();
        //write y graticules
        let firstYMapDist = ((parseInt(topLeftY / graticuleSize)) * graticuleSize - topLeftY);
        let firstYVal = parseInt(topLeftY + firstYMapDist);
        let firstY = 18 - firstYMapDist / mapscale * 1000;
        ctx.beginPath();
        ctx.moveTo(12, firstY);
        ctx.lineTo(237, firstY);
        ctx.strokeStyle = '#566573'
        ctx.lineWidth = 0.15;
        ctx.stroke();
        ctx.fillStyle = "black";
        ctx.textAlign = "center";
        ctx.font = "2px Arial";
        //++check this if it is necessary?
        ctx.save();
        ctx.save();
        ctx.save();
        ctx.save();
        ctx.save();
        ctx.save();
        ctx.save();


        ctx.translate(11, firstY);
        ctx.rotate(-Math.PI / 2);
        ctx.fillText(firstYVal, 0, 0);
        ctx.restore();
        ctx.translate(239.5, firstY);
        ctx.rotate(-Math.PI / 2);
        ctx.fillText(firstYVal, 0, 0);
        ctx.restore();

        while ((firstY + 50) < 198) {
            firstY = firstY + 50;
            firstYVal = firstYVal - graticuleSize;
            ctx.beginPath();
            ctx.moveTo(12, firstY);
            ctx.lineTo(237, firstY);
            ctx.strokeStyle = '#566573'
            ctx.lineWidth = 0.2;
            ctx.stroke();

            ctx.restore();
            ctx.translate(11, firstY);
            ctx.rotate(-Math.PI / 2);
            //ctx.fillText(firstYVal, 0, 0);
            ctx.fillText(Math.round(firstYVal), 0, 0);

            ctx.restore();
            ctx.translate(239.5, firstY);
            ctx.rotate(-Math.PI / 2);
            //ctx.fillText(firstYVal, 0, 0);
            ctx.fillText(Math.round(firstYVal), 0, 0);
            ctx.restore();
        }
    }
    requestAnimationFrame(draw)
}


function wrapText(ctx, text, x, y, maxWidth, lineHeight) {

    var words = [];
    if (text.toString().includes(' ')) {
        words = text.split(' ');
    }
    else {
        words[0] = text;
    }
    var line = '';

    for (var n = 0; n < words.length; n++) {
        var testLine = line + words[n] + ' ';
        var metrics = ctx.measureText(testLine);
        var testWidth = metrics.width;
        if (testWidth > maxWidth && n > 0) {
            ctx.fillText(line, x, y);
            line = words[n] + ' ';
            y += lineHeight;
        }
        else {
            line = testLine;
        }
    }
    ctx.fillText(line, x, y);
}

// number with thousand separater
function numberWithCommas(x) {
    return x.toString().replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, ",");
}