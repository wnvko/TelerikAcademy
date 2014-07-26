﻿var tags = ["cms", "javascript", "js",
            "ASP.NET MVC", ".net", ".net", "css",
            "wordpress", "xaml", "js", "http", "web",
            "asp.net", "asp.net MVC", "ASP.NET MVC",
            "wp", "javascript", "js", "cms", "html",
            "javascript", "cms", "cms", "http", "http", "CMS"];

    tagSet = getTagSet(tags);
    maxCount = getMaxCount(tagSet);
    minCount = getMinCount(tagSet);
    countInterval = maxCount - minCount;
    fontSizeInterval = maxFontSize - minFontSize;

    for (var tag in tagSet) {
        var nextSpan = document.createElement('div');
        nextSpan.innerHTML = tag;
        var fontSize = tagSet[tag] * fontSizeInterval / countInterval + minFontSize;
        nextSpan.style.fontSize = fontSize + 'px';
        nextSpan.style.display = 'inline-block';
        nextSpan.style.margin = '5px';
        tagCloudHolder.appendChild(nextSpan);
    }

    tagCloudHolder.style.border = '1px solid black';
    tagCloudHolder.style.width = '300px';
    document.body.appendChild(tagCloudHolder);
}
    for (var i = 0, length = tags.length; i < length; i++) {
        if (isNaN(tagSet[tags[i].toLowerCase()])) {
            tagSet[tags[i].toLowerCase()] = 1;
        } else {
            tagSet[tags[i].toLowerCase()]++;
        }
    }

    return tagSet;
}
    for (var tag in tagSet) {
        if (maxCount < tagSet[tag]) {
            maxCount = tagSet[tag];
        }
    }

    return maxCount;
}

function getMinCount(tagSet) {
    for (var tag in tagSet) {
        if (minCount > tagSet[tag]) {
            minCount = tagSet[tag];
        }
    }

    return minCount;
}