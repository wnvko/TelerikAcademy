/// <reference path="../libs/require.js" />
'use strict';
define(function () {
    var Item;

    Item = (function () {
        function Item(type, name, price) {
            var NAME_MAX_LENGHT = 40,
                NAME_MIN_LENGHT = 6;

            var isCorrectType = type === 'accessory' ||
                                type === 'smart-phone' ||
                                type === 'notebook' ||
                                type === 'pc' ||
                                type === 'tablet';

            var iscorrectName = NAME_MIN_LENGHT <= name.length && name.length <= NAME_MAX_LENGHT;
            if (isCorrectType) {
                this.type = type;
            }
            else {
                throw "The item type can only be accessory, smart-phone, notebook, pc or tablet.";
            }

            if (iscorrectName) {
                this.name = name;
            }
            else {
                throw 'The item name must be 6 - 40 chars in length.';
            }

            this.price = price;
        }

        return Item;
    }());

    return Item;
});