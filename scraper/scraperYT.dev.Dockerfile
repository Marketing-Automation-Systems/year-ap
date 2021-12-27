# FROM ubuntu:20.04
FROM debian:11

# For avoiding prompts
ENV DEBIAN_FRONTEND=noninteractive

# Get repository sources
RUN apt-get update \
	&& apt-get install -y \
		# Basic tools we will need for everything else
		bash unzip procps wget python3-pip \
		# For running the GUI
		xvfb fluxbox wmctrl \
		# For debugging the GUI
		x11vnc \
		# We will need these for Chrome + Undetected Chrome
		default-jre 

# Install Chrome
RUN echo 'deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main' \
		> /etc/apt/sources.list.d/google-chrome.list \
	&& wget -O- https://dl.google.com/linux/linux_signing_key.pub 2> /dev/null \
		| gpg --dearmor > /etc/apt/trusted.gpg.d/google.gpg \
	&& apt-get update \
	&& apt-get install -y google-chrome-stable

# TODO: install from requirements.txt file
# Install necessary Python libraries
COPY python_requirements.txt /tmp/
RUN python3 -m pip install -r /tmp/python_requirements.txt \
	&& rm /tmp/python_requirements.txt

# Install BrowserMobProxy binaries
RUN wget https://github.com/lightbody/browsermob-proxy/releases/download/browsermob-proxy-2.1.4/browsermob-proxy-2.1.4-bin.zip \
		-O browsermob.zip 2> /dev/null \
	&& unzip browsermob.zip -d /opt/ \
	&& rm browsermob.zip

# For development and debugging -- will be excluded in production Dockerfile
RUN apt-get install -y less vim curl

RUN mkdir -p /opt/scraper/
COPY src/ /opt/scraper/

COPY yt_bootstrap.sh /

# Add regular user, give them ownership of binaries
RUN useradd apps \
    && mkdir -p /home/apps/Downloads \
    && chown -v -R apps:apps /home/apps \
	&& usermod -aG sudo apps \
	&& chown -R apps:apps /opt/

# Make regular user able to write log files
RUN chmod a+w /var/log/

CMD [ "/yt_bootstrap.sh" ]