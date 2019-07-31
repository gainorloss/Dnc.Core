# VuePress搭建在綫文檔

目錄結構

```
|--package.json
|--docs
   |--README.md(默认路由/访问)
   |--.vuepress
      |--config.js
```
config.js配置如下包含头部导航条

```
/**
 * title,description
 */
module.exports = {
    title: 'node_samples',
    description: 'node samples',
    themeConfig: {
     nav: [
         { text: '主页', link: '/' },
         { text: '博文',
           items: [
             { text: 'Android', link: '/android/' },
             { text: 'ios', link: '/ios/' },
             { text: 'Web', link: '/web/' }
           ] 
         },
         { text: '关于', link: '/about/' },
         { text: 'Github', link: 'https://www.github.com/codeteenager' },
     ],
     sidebar: {
         '/android/': ["","android1"],
             "/ios/":["","ios1",],
             "/web/":["","web1"],
         },
     sidebarDepth: 2,
     lastUpdated: 'Last Updated'
 },
}
```

1. 安裝
 
``` 
/*安裝vuepress*/
npm i -D vuepress
//
mkdir docs
```

2. 基本配置



3. dev啓動

```
npx vuepress dev docs
```

4. 生成文檔

```
npm vuepress build docs
```