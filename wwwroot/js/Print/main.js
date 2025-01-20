const dims = {
    a0: [1189, 841],
    a1: [841, 594],
    a2: [594, 420],
    a3: [420, 297],
    a4: [225, 180],
    a5: [210, 148],
  };
function load_png() 
{
    mapCanvas = document.createElement('canvas');
    const size = mape.getSize();
    mapCanvas.width = size[0];
    mapCanvas.height = size[1];
    const mapContext = mapCanvas.getContext('2d');
    mape.once('rendercomplete', function () {
        Array.prototype.forEach.call(
            mape.getViewport().querySelectorAll('.ol-layer canvas, canvas.ol-layer'),
            function (canvas) {
                if (canvas.width > 0) {
                    const opacity =
                        canvas.parentNode.style.opacity || canvas.style.opacity;
                    mapContext.globalAlpha = opacity === '' ? 1 : Number(opacity);
                    let matrix;
                    const transform = canvas.style.transform;
                    if (transform) {
                        // Get the transform parameters from the style's transform matrix
                        matrix = transform
                            .match(/^matrix\(([^\(]*)\)$/)[1]
                            .split(',')
                            .map(Number);
                    } else {
                        matrix = [
                            parseFloat(canvas.style.width) / canvas.width,
                            0,
                            0,
                            parseFloat(canvas.style.height) / canvas.height,
                            0,
                            0,
                        ];
                    }
                    // Apply the transform to the export map context
                    CanvasRenderingContext2D.prototype.setTransform.apply(
                        mapContext,
                        matrix
                    );
                    const backgroundColor = canvas.parentNode.style.backgroundColor;
                    if (backgroundColor) {
                        mapContext.fillStyle = backgroundColor;
                        mapContext.fillRect(0, 0, canvas.width, canvas.height);
                    }
                    mapContext.drawImage(canvas, 0, 0);
                }
            }
        );
        mapContext.globalAlpha = 1;
        mapContext.setTransform(1, 0, 0, 1, 0, 0);
        const link = document.getElementById('image-download');
        link.href = mapCanvas.toDataURL();
    });
    mape.renderSync();    
}


//function get_map_image () {   
//    document.body.style.cursor = 'progress';

//    const format = 'a4';
//    const resolution = 300;
//    const dim = dims[format];
//    const width = Math.round((dim[0] * resolution) / 25.4);
//    const height = Math.round((dim[1] * resolution) / 25.4);
//    const size = mape.getSize();
//    const viewResolution = mape.getView().getResolution();
//    const mapCanvas = document.createElement('canvas');


//    mape.setSize(size);
//    mape.getView().setResolution(viewResolution);   
//    document.body.style.cursor = 'auto';
  
//    let map_image = new Image();
//    map_image.src = mapCanvas.toDataURL('image/jpeg');
//    return map_image; 
   
//}
