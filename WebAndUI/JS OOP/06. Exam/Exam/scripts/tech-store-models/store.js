/// <reference path="../libs/require.js" />
define(function () {
    var Store;

    Store = (function () {
        function Store(name) {
            var NAME_MAX_LENGHT = 30,
                NAME_MIN_LENGHT = 6;

            var iscorrectName = NAME_MIN_LENGHT <= name.length && name.length <= NAME_MAX_LENGHT;

            if (iscorrectName) {
                this.name = name;
            }
            else {
                throw 'The item name must be 6 - 30 chars in length.';
            }

            this.items = [];
        }

        Store.prototype.addItem = function (item) {
            this.items.push(item);
            return this;
        };

        Store.prototype.getAll = function () {
            return sortItems(this.items, 'name');
        };

        Store.prototype.getSmartPhones = function () {
            var len = this.items.length,
                i,
                smartPhones = [];

            for (var i = 0; i < len; i++) {
                if (this.items[i].type === 'smart-phone') {
                    smartPhones.push(this.items[i]);
                }
            }

            return sortItems(smartPhones, 'name');
        };

        Store.prototype.getMobiles = function () {
            var len = this.items.length,
                i,
                mobiles = [];

            for (var i = 0; i < len; i++) {
                if (this.items[i].type === 'smart-phone' || this.items[i].type === 'tablet') {
                    mobiles.push(this.items[i]);
                }
            }

            return sortItems(mobiles, 'name');
        }

        Store.prototype.getComputers = function () {
            var len = this.items.length,
                i,
                computers = [];

            for (var i = 0; i < len; i++) {
                if (this.items[i].type === 'pc' || this.items[i].type === 'notebook') {
                    computers.push(this.items[i]);
                }
            }

            return sortItems(computers, 'name');
        }

        Store.prototype.filterItemsByType = function (filterType) {
            var len = this.items.length,
                i,
                filtered = [];

            for (var i = 0; i < len; i++) {
                if (this.items[i].type === filterType) {
                    filtered.push(this.items[i]);
                }
            }

            return sortItems(filtered, 'name');
        };

        Store.prototype.filterItemsByPrice = function (priceRange) {

            var len = this.items.length,
                i,
                inRage = [],
                minPrice,
                maxPrice;

            if (!priceRange) {
                return sortItems(this.items, 'name');
            }

            minPrice = priceRange.min || 0;
            maxPrice = priceRange.max || Infinity;


            for (var i = 0; i < len; i++) {
                if (minPrice < this.items[i].price && this.items[i].price < maxPrice) {
                    inRage.push(this.items[i]);
                }
            }

            return sortItems(inRage, 'price');
        }

        Store.prototype.countItemsByType = function () {
            var len = this.items.length,
                i,
                types = [];

            for (var i = 0; i < len; i++) {
                var currentItemType = this.items[i].type;

                if (types.hasOwnProperty(currentItemType)) {
                    types[currentItemType] += 1;
                }
                else {
                    types[currentItemType] = 1;
                }
            }

            return types;
        };

        Store.prototype.filterItemsByName = function (partOfName) {
            var len = this.items.length,
                i,
                byPartName = [];

            for (var i = 0; i < len; i++) {
                if (this.items[i].name.toLowerCase().indexOf(partOfName.toLowerCase()) !== -1) {
                    byPartName.push(this.items[i]);
                }
            }

            return sortItems(byPartName, 'name');
        };

        function sortItems(items, sortBy) {
            items.sort(function (first, second) {

                var firstArg = first[sortBy],
                    secondArg = second[sortBy];

                if (isNaN(firstArg)) {
                    firstArg = firstArg.toLowerCase();
                }

                if (isNaN(secondArg)) {
                    secondArg = secondArg.toLowerCase();
                }

                if (firstArg < secondArg) {
                    return -1;
                }

                if (firstArg > secondArg) {
                    return 1;
                }

                return 0;
            })

            return items;
        }

        return Store;
    }());

    return Store;
});