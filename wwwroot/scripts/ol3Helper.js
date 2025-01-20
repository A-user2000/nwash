/**
 * 
 * Ol3 is still lacking basic functionalities, so I am writing some helper functions that I needed on my daily life.
 * @type type
 */
var ol3Helper = {
    /**
     * Sear
     * @param {type} collection
     * @param {type} featureId
     * @returns {ol.feature} feature
     */

    searchFeatureInCollectionsById: function (collection, featureId)
    {
        var feature;
        var features_arr = collection.features.getArray();
        for (var i = 0; i < features_arr.length; i++)
        {
            feature = features_arr[i];
            if (feature.getId() == featureId)
            {
                return feature;
            }
        }
        return null;
    }
}

