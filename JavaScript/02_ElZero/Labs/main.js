document.querySelector('h1').style.color = 'red';

// window.alert('Hello, World!');

console.log('%cHello, World!', "color: blue; font-size: 20px; background-color: yellow; padding: 5px; border-radius: 5px;");

console.error('This is an error message.');

console.table({ name: 'Alice', age: 30 });
console.table([{ name: 'Bob', age: 25 }, { name: 'Carol', age: 28 }, "Ahmed"]);

console.time('Timer');
for (let i = 0; i < 1000000; i++) {
  // Simulate a time-consuming task
}

console.timeEnd('Timer');

console.warn('This is a warning message.');

console.info('This is an informational message.');

console.debug('This is a debug message.');

console.trace('Trace message');

console.group('Grouped Messages');
console.log('Message 1');
console.log('Message 2');
console.groupEnd();


// console.clear();
