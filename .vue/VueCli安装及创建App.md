# VueCli安装及创建App

## VueCli安装

1. 安装或升级*VueCli*

```
# i 是install 缩写

# 国内先安装cnpm替代npm,使用基本一样，不然有点慢
npm i -g cnpm

# 接下来使用*cnpm*安装或者更新*@vue/cli*
cnpm i -g @vue/cli

# 查看VueCli版本
vue --version
```

2. 创建*app*,设置一个*app*的名称，单词之间'-'隔开

```
vue create vue-client-app
cd vue-cli-app
npm run serve
```

3. 安装 *axios* 和 *element*

``` javascript
npm i -S axios
vue add element
```

4. 配置*mock api*

根目录新建 *vue.config.js*
内容如下

``` javascript
module.exports={
    configureWebpack:{
        devServer:{
            before(app){
                app.get('/api/goods',(req,res)=>{
                    return res.json([
                        { id: 1, prodName: "吐司", price: 23.8 },
                        { id: 2, prodName: "三用早饭机", price: 199 }
                      ]);
                })
            }
        }
    }
}
```
