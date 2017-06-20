﻿<?php
	 class C_tpls_info extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLS_INFO.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLS_INFO.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpls_infoid' =>  $this->input->get_post('tpls_infoid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
                ,'schema_imagefile' =>   $this->input->get_post('schema_imagefile', TRUE)
                ,'schema_imagefile_ext' =>   $this->input->get_post('schema_imagefile_ext', TRUE)
            );
            $tpls_info = $this->m_tpls_info->setRow($data);
            print json_encode($tpls_info);
    }
    function newRow() {
            log_message('debug', 'TPLS_INFO.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpls_infoid' =>  $this->input->get_post('tpls_infoid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
                ,'schema_imagefile' =>   $this->input->get_post('schema_imagefile', TRUE)
                ,'schema_imagefile_ext' =>   $this->input->get_post('schema_imagefile_ext', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpls_info= $this->m_tpls_info->newRow($instanceid,$data);
            $return = $tpls_info;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLS_INFO.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpls_info = $this->m_tpls_info->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpls_info
            );
            print json_encode($return);
        }
    }
    function getRows() {
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpls_info= $this->m_tpls_info->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpls_info= $this->m_tpls_info->getRows($sort);
                }
            }else{
              $tpls_info= $this->m_tpls_info->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpls_info
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLS_INFO.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpls_info= $this->m_tpls_info->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpls_info
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need instanceid to query.'
            );
        }
        print json_encode($return);
    }
    function getRowsByParent() {
        log_message('debug', 'TPLS_INFO.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpls_info= $this->m_tpls_info->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpls_info
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need parent parentid to query.'
            );
        }
        print json_encode($return);
    }
    function deleteRow() {
        log_message('debug', 'TPLS_INFO.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpls_infoid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpls_info->deleteRow($tempId);
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'No  ID to delete'
            );
        }
        print json_encode($return);
    }
    private function _loadModels () {
        $this->load->model('M_tpls_info', 'm_tpls_info');
    }
}
?>