
<template>
    <div class="center ">
        <!--<div id="target">Your message will be typed out here!</div>-->
        <vue-typing :text="myText" />
        <button @click="type()" :rewrite="true">点击</button>
    </div>
</template>

<script>
import VueTyping from 'vue-typing'
export default {
    name:'Notice',
    components: { VueTyping },
    data () {
        return {
            retypex:0,
            myText: '给游客的告知',
            myCursor: { blinking: false, cursor: " ", color: "black", framerate: 0}
        }
    },
    methods: {
        type () {
            this.retypex=1-this.retypex
            this.myText = `欢迎各位游客：

为打造更完美的以满足游客主题体验为中心的3.0时代，同济集团联合周边资源造倾力打造的一系列主题酒店。三十多年品质的地道特色餐饮悉数传承，百间卡通动物主题客房、多项趣味亲子互动设施，为您带来舒适温馨的度假体验。

所有食材都由我们为您精心挑选。酒店专有的免费摆渡车可以载您前往动物园，快捷方便。在这里，您可以尽情体验各种乐趣，像孩子一般的纵情欢笑。

每一处细节的精心打造，只为让您尽享奇妙体验。

祝您度过在这度过愉快的时光`
            this.myText=this.myText+(this.retypex?' ':'   ')
        }
    }
}
</script>
<style scoped lang="scss">
    //@import 'https://fonts.googleapis.com/css?family=Fira+Mono';


html {
	font-size: 18px;
}

body {
	color: #333;
	background: #f8f8f8;
	font-family: 'Fira Mono', mono;
	font-size: 1rem;
	margin: 0;
	display: grid;
	width: 100%;
	height: 100vh;
	justify-items: center;
	align-items: center;
	padding: 0 6vw;
	box-sizing: border-box;
	line-height: 1.4;
}

div {
	width: 100%;
	max-width: 30em;
	white-space: pre-line;
}

div:after {
	content: '|';
	animation: cursor 1s linear infinite;
}

button {
	font-family: 'Fira Mono', mono;
	padding: 1em;
	font-size: 14px;
	border-radius: 4px;
	background: transparent;
	border: 2px solid #a7a8aa;
	color: #a7a8aa;
	cursor: pointer;
}

@keyframes cursor {
	0% {
		opacity: 0;
	}
	49.9% {
		opacity: 0;
	}
	50% {
		opacity: 0;
	}
	99.9% {
		opacity: 0;
	}
}
.center{
    margin:20px auto;
	text-align:center;
}
</style>
