MAKE="gmake"
MSBUILD="msbuild"
GULP="gulp"

task :default => "build"

task :build do
	sh "#{GULP} build:ExtremeSports --debug"
	sh "#{GULP} build --debug"
end

task :clean do
	sh "npm install"
end

