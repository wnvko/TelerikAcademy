var navModel = [{
        url: 'home',
        title: 'Home'
    }, {
        url: 'phones',
        title: 'Smart Phones'
    }, {
        url: 'tablets',
        title: 'Tablets'
    }, {
        url: 'wearables',
        title: 'Wearables'
    }];

var mainModel = {
    nav: navModel,
}

var phonesModel = {
    nav: navModel,
    phones : ['Samsung Galaxy S70', 'Apple iPhone 56', 'Sony Xperia 34']
};

var tabletsModel = {
    nav: navModel,
    tablets : ['Samsung Tab S70', 'Apple iPad 56', 'Sony Xperia Z34 Tablet']
};

var wearablesModel = {
    nav: navModel,
    wearables : ['Samsung Gear S70', 'Apple Watch 56', 'Sony SmarthWatch 56']
};


module.exports = {
    navModel : navModel,
    mainModel: mainModel,
    phonesModel : phonesModel,
    tabletsModel : tabletsModel,
    wearablesModel: wearablesModel
}

