var gulp = require('gulp');
var concat = require('gulp-concat');
var sass = require('gulp-sass');
var babelify = require('babelify');
var browserify = require('browserify');
var source = require('vinyl-source-stream');
var pleeease = require('gulp-pleeease');
var uglify = require('gulp-uglify');
var streamify = require('gulp-streamify');
var yargs = require('yargs');

var destinationPath = 'output';
var buildRelease = yargs.argv.release || false;

gulp.task('code', function(){
	var pipeline = browserify({
		entries: 'app/layout/index.jsx',
		extensions: ['.jsx'],
		debug: true
	})
		.transform(babelify)
		.bundle()
		.pipe(source('site.js'));

	if (buildRelease) {
		pipeline.pipe(streamify(uglify()));
	}

	pipeline
		.pipe(gulp.dest(destinationPath));
});

gulp.task('css', function(){
	gulp
		.src([
			'app/site.scss',
			'app/**/*.css'
		])
		.pipe(sass().on('error', sass.logError))
		.pipe(pleeease())
		.pipe(concat('site.css'))
		.pipe(gulp.dest(destinationPath));
});

gulp.task('vendor', function(){
	gulp
		.src([])
		.pipe(concat('vendor.js'))
		.pipe(uglify())
		.pipe(gulp.dest(destinationPath));
	gulp
		.src([])
		.pipe(concat('vendor.css'))
		.pipe(pleeease())
		.pipe(gulp.dest(destinationPath))
});

gulp.task('html', function(){
	gulp
		.src('app/index.html')
		.pipe(gulp.dest(destinationPath));
});

gulp.task('default', ['code', 'css', 'html', 'vendor']);

gulp.task('watch', ['default'], function() {
	gulp.watch(
		['app/**/*.jsx'], 
		['code']);
	gulp.watch(
		['app/**/*.css', 'app/**/*.scss'],
		['css']);
	gulp.watch(
		['app/index.html'],
		['html']);
});